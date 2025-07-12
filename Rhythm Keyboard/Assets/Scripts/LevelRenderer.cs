using UnityEngine;
using UnityEngine.Video;
public class LevelRenderer : MonoBehaviour
{
    [SerializeField] private VideoClip[] levelBackgroundVideos;
    [SerializeField] private float[] levelLengths;

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
        new double[] {0, 0.9166666666, 3.6666666667, 4.5833333333, 7.3333333333, 8.25, 11, 11.9166666667} //C5
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
    }
    
}
