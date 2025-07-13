using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    private float startTime;
    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        if (GameInfo.gameActive)
        {
            
            // On game start, record the start time
            if (GameInfo.beatsElapsed == 0)
                startTime = (float)(Time.time + GameInfo.levelStartDelay);

            // Calculate beatsElapsed based on elapsed real time
            GameInfo.beatsElapsed = (Time.time - startTime) * GameInfo.initialBPM / 60f;
            
            timerText.text = "Time: " + GameInfo.beatsElapsed.ToString("F2") + " beats";

            Debug.Log("BPM: "+ GameInfo.initialBPM);
        }
        else
        {
            GameInfo.beatsElapsed = 0;
        }
    }
}