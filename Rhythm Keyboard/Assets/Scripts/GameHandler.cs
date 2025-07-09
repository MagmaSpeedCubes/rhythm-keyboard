using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public void StartGame()
    {
        GameInfo.gameActive = true;
        GameInfo.beatsElapsed = 0;
    }
}
