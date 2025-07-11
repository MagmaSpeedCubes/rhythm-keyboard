using UnityEngine;

public class Timer : MonoBehaviour
{
    void Update()
    {
        if (GameInfo.gameActive)
        {
            GameInfo.beatsElapsed += Time.deltaTime * GameInfo.BPM / 60;

        }
        else
        {
            GameInfo.beatsElapsed = 0; // Reset beats elapsed when the game is not active
        }
    }
}
