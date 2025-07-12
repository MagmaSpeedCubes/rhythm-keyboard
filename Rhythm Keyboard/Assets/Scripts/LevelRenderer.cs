using UnityEngine;
using UnityEngine.Video;
public class LevelRenderer : MonoBehaviour
{
    [SerializeField] private VideoClip[] levelBackgroundVideos;
    [SerializeField] private float[] levelLengths;

    [SerializeField] private AudioClip[] levelMusic;
    [SerializeField] private float[] levelMusicOffsetTimes;
    [SerializeField] private AudioSource levelAudioSource;

    private double[][] level0Notes = new double[][]
    {
        new double[] {}, //C4
        new double[] {1, 2, 3, 5, 8, 10 }, //Cs4
        new double[] {1, 2, 3, 5, 8, 10 }, //D4
        new double[] {1, 2, 3, 5, 8, 10 }, //Ds4
        new double[] {1, 2, 3, 5, 8, 10 }, //E4
        new double[] {1, 2, 3, 5, 8, 10 }, //F5
        new double[] {1, 2, 3, 5, 8, 10 }, //Fs4
        new double[] {1, 2, 3, 5, 8, 10 }, //G5
        new double[] {1, 2, 3, 5, 8, 10 }, //Gs4
        new double[] {1, 2, 3, 5, 8, 10 }, //A4
        new double[] {1, 2, 3, 5, 8, 10 }, //As4
        new double[] {1, 2, 3, 5, 8, 10 }, //B4
        new double[] {0, 11/12, 33/12, 44/12, 44/12, 55/12, 77/12, 88/12, 88/12, 99/12, 121/12, 12*11/12, 12*11/12, 13*11/12, 15*11/12, 16*11/12, 16*11/12, 17*11/12} //C5
        //This is a placeholder sequence, replace with actual sequences.
    };

    public void RenderLevel()
    {
        int levelIndex = GameInfo.selectedLevel;
        if (levelIndex == 0)
        {
            GameHandler gameHandler = GetComponent<GameHandler>();
            gameHandler.ImportNoteSequence(level0Notes);
        }
        levelAudioSource.clip = levelMusic[levelIndex];
        levelAudioSource.PlayDelayed((float)(GameInfo.levelStartDelay + levelMusicOffsetTimes[levelIndex]));

    }
    
}
