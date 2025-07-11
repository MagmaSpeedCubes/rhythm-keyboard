using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Difficulty : MonoBehaviour
{
    public int index;

    private readonly string[] difficulties = { "Base", "Pro", "Max" };

    private readonly string[] descriptions ={
    "The base difficulty for casual players",
    "Increased note count and decreased miss tolerance",
    "A less lenient challenge, for those who dare"
    
    };
    private readonly double[] bpmMultipliers = { 1, 1, 1.5};

    private readonly int[] extraNoteMultipliers = { 0, 2, 3};
    private readonly double[] toleranceMultipliers = { 1, 0.7, 0.4};
    private readonly int[] scoreMultipliers = { 10, 14, 18};
    [SerializeField] private Color[] colors = { new Color(1f, 1f, 1f), new Color(1f, 0f, 0f), new Color(0f, 0f, 1f), new Color(1f, 0f, 1f) };

    [SerializeField] private TextMeshProUGUI modeText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    private float tick;
    public void Refresh()
    {
        modeText.text = difficulties[index];
        modeText.color = colors[index];
        descriptionText.text = descriptions[index];
        descriptionText.color = colors[index];
        GameInfo.BPM = (int)(GameInfo.initialBPM * bpmMultipliers[index]);

        GameInfo.noteSpeed = bpmMultipliers[index];
        GameInfo.difficulty = index;
    }


    public void Increase()
    {
        if (index < difficulties.Length - 1)
        {
            index++;
            Refresh();
        }
    }

    public void Decrease()
    {
        if (index > 0)
        {
            index--;
            Refresh();
        }
    }

    void Start()
    {
        Refresh();
    }
    void Update()
    {
        int loopTime = 1;
        if (index == 3)
        {
            modeText.color = Color.Lerp(colors[2], colors[1], Mathf.PingPong(tick, loopTime) / loopTime);
            tick += Time.deltaTime;
            if (tick >= loopTime)
            {
                tick = 0;
            }
        }
        //shows fading colors when "Ultra" difficulty is selected
    }



}
