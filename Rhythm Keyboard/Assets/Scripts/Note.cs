using UnityEngine;

public class Note : MonoBehaviour
{


    //adjust these later based on gameplay testing



    public double startTime;

    public double endTime;

    private bool isHoldNote;

    //time is stored in beats
    void Start()
    {
        SetNoteLength();

    }


    public void Update()
    {

        double distanceMultiplier = GameInfo.noteSpeed;

        double yOffset = -0.1; // adjust as needed

        float noteHeight = transform.localScale.y;
        float bottomY = (float)(distanceMultiplier * (startTime - GameInfo.beatsElapsed) + yOffset);

        // Offset by half the height so the bottom stays at bottomY
        float centerY = bottomY + noteHeight / 2f;

        transform.position = new Vector3(transform.position.x, centerY, transform.position.z);

        if (startTime < GameInfo.beatsElapsed)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 0.5f);
        }
        if (endTime < GameInfo.beatsElapsed)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.5f);
        }

        if (endTime < GameInfo.beatsElapsed - 4)
        {
            Destroy(gameObject);
        }
    }


    private void SetNoteLength()
    {
        double duration = endTime - startTime;
        //if (duration < 1) { duration = 1; } // Prevent zero or negative scale
        if (duration == 1) { isHoldNote = false; } // If the duration is 1, it's not a hold note
        else { isHoldNote = true; }

        Vector3 scale = transform.localScale;
        scale.y = (float) (duration * GameInfo.noteSpeed);
        transform.localScale = scale;
    }


}