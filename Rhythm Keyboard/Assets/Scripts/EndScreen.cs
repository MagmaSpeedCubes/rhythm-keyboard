using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class EndScreen : MonoBehaviour
{

    [SerializeField] private Canvas keyboard;
    [SerializeField] private Canvas endScreen;
    [SerializeField] private TextMeshProUGUI statText;
    [SerializeField] private Image rankImage;
    [SerializeField] private Sprite[] rankSprites;
    //Rank sprites in order
    //D, C, B, A, S, SS, U, X, X+
    private float[] rankThresholds =
    {
        0f, //D
        0.2f, //C
        0.4f, //B
        0.6f, //A
        0.8f, //S
        0.9f, //SS
        0.95f, //U
        0.98f, //X
        0.99f //X+

        };
    [SerializeField] private float rankShuffleTime;


    public void EndLevel()
    {
        keyboard.enabled = false;
        endScreen.enabled = true;


        GameInfo.gameActive = false;
        int rankIndex = CalculateRank();
        StartCoroutine(ShuffleRank(rankIndex, rankShuffleTime));


    }

    public int CalculateRank()
    {
        int score = GameInfo.score;
        int perfectScore = GameInfo.levelPerfectScore;
        float percentage = (float)score / perfectScore;
        int rankIndex = 0;
        for (int i = 0; i < rankThresholds.Length; i++)
        {
            if (percentage >= rankThresholds[i])
            {
                rankIndex = i;
            }
        }
        return rankIndex;
        //calculates the rank based on percentage of perfect score


    }

    public IEnumerator ShuffleRank(int rankIndex, float time)
    {
        
        //this represents the number of ranks before rankIndex
        for (int i = 0; i < rankIndex; i++)
        {
            rankImage.sprite = rankSprites[i];
            yield return new WaitForSeconds(time / rankIndex);
        }
        rankImage.sprite = rankSprites[rankIndex];
        //sets the rank image to the final rank after shuffling
    }
}
