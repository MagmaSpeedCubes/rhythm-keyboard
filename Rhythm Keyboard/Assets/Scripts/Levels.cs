using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class Levels : MonoBehaviour
{
    public int index = 0;
    public string[] levelNames;
    public int[] levelDifficulties;
    public int[] levelBPM;
    public AudioClip[] levelPreviewMusic;
    public Sprite[] levelPreviewImages;
    [SerializeField] private int[] levelScores;


    [SerializeField] private TextMeshProUGUI LevelNameText;
    [SerializeField] private TextMeshProUGUI LevelInfoText;
    [SerializeField] private Image LevelPreviewImage;
    [SerializeField] private AudioSource LevelPreviewAudio;

    public void Refresh()
    {
        LevelNameText.text = levelNames[index];
        LevelInfoText.text = "Difficulty: " + levelDifficulties[index] + " | BPM: " + levelBPM[index] + " | Score: " + levelScores[index];
        if (levelPreviewImages[index] != null)
        {
            LevelPreviewImage.sprite = levelPreviewImages[index];

        }
        else
        {
            LevelPreviewImage.sprite = null;
        }


        if (levelPreviewMusic[index] != null)
        {
            LevelPreviewAudio.clip = levelPreviewMusic[index];
            if (!LevelPreviewAudio.isPlaying)
            {
                LevelPreviewAudio.Play();
            }
        }
        else
        {
            LevelPreviewAudio.Stop();

        }
        GameInfo.initialBPM = levelBPM[index];



    }

    public void NextLevel()
    {
        if (index < levelNames.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0; // Loop back to the first level
        }
        Refresh();
    }

    public void PreviousLevel()
    {
        if (index > 0)
        {
            index--;
        }
        else
        {
            index = levelNames.Length - 1; // Loop back to the last level
        }
        Refresh();
    }

    public void StopAudio()
    {
        if (LevelPreviewAudio.isPlaying)
        {
            LevelPreviewAudio.Stop();
        }
    }

    void Start()
    {
        Refresh();
    }




}
