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
        new double[] {}, //Cs4
        new double[] {}, //D4
        new double[] {}, //Ds4
        new double[] {}, //E4
        new double[] {}, //F5
        new double[] {}, //Fs4
        new double[] {}, //G5
        new double[] {1, 2, 5, 6, 9, 10, 13, 14, 17, 18, 21, 22, 25, 26, 29, 30, 33, 34, 37, 38, 41, 42, 45, 46}, //Gs4
        new double[] {}, //A4
        new double[] {2, 3, 6, 7, 10, 11, 14, 15, 18, 19, 22, 23, 26, 27, 30, 31, 34, 35, 38, 39, 42, 43, 46, 47}, //As4
        new double[] {}, //B4
        new double[] {0, 1, 3, 4, 4, 5, 7, 8, 8, 9, 11, 12, 12, 13, 15, 16, 16, 17, 19, 20, 20, 21, 23, 24
        , 24, 25, 27, 28, 28, 29, 31, 32, 32, 33, 35, 36, 36, 37, 39, 40, 40, 41, 43, 44, 44, 45, 47, 48} //C5
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
