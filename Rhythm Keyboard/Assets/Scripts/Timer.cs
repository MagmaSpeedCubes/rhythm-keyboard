using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;

    void Update()
    {
        if (GameInfo.gameActive)
        {
            // On game start, record the start time
            if (GameInfo.beatsElapsed == 0)
                startTime = (float) (Time.time + GameInfo.levelStartDelay);

            // Calculate beatsElapsed based on elapsed real time
            GameInfo.beatsElapsed = (Time.time - startTime) * GameInfo.BPM / 60f;
        }
        else
        {
            GameInfo.beatsElapsed = 0;
        }
    }
}