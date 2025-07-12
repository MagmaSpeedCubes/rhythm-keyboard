using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.UI;
using TMPro;
public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;

    [SerializeField] private GameObject C4;
    [SerializeField] private GameObject Cs4;
    [SerializeField] private GameObject D4;
    [SerializeField] private GameObject Ds4;
    [SerializeField] private GameObject E4;
    [SerializeField] private GameObject F4;
    [SerializeField] private GameObject Fs4;
    [SerializeField] private GameObject G4;
    [SerializeField] private GameObject Gs4;
    [SerializeField] private GameObject A4;
    [SerializeField] private GameObject As4;
    [SerializeField] private GameObject B4;
    [SerializeField] private GameObject C5;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI noteText;
    [SerializeField] private Color[] noteTextColors; 



    
    //private double[][] noteSequence;

    private double[][] noteSequence = new double[][]
    {
        new double[] {1, 2, 3, 5, 8, 10 }, //C4
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
        new double[] {1, 2, 3, 5, 8, 10 } //C5
        //This is a placeholder sequence, replace with actual sequences.
    };
    //for testing purposes.

    //even indices are rests, odd indices are notes
    //times must be written in beats and absolute

    private static GameHandler instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Multiple GameHandler instances detected. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }
    }

    public void StartGameButton()
    {
        if (!GameInfo.gameActive)
        {
            StartCoroutine(StartGame());
        }
        else
        {
            Debug.LogWarning("Game is already active.");
        }
    }
    public IEnumerator StartGame()
    {
        GameInfo.gameActive = true;
        GameInfo.beatsElapsed = 0;

        LevelRenderer levelRenderer = GetComponent<LevelRenderer>();
        levelRenderer.RenderLevel();

        yield return new WaitForSeconds((float)GameInfo.levelStartDelay);
        //Base notes: F4, G4, A4, B4, C5
        //Pro notes: C4, D4, E4
        //Max notes: Cs4, Ds4, Fs4, Gs4, As4
        StartCoroutine(SpawnNotes(F4, noteSequence[5]));
        StartCoroutine(SpawnNotes(G4, noteSequence[7]));
        StartCoroutine(SpawnNotes(A4, noteSequence[9]));
        StartCoroutine(SpawnNotes(B4, noteSequence[11]));
        StartCoroutine(SpawnNotes(C5, noteSequence[12]));
        if (GameInfo.difficulty >= 1)
        {
            StartCoroutine(SpawnNotes(C4, noteSequence[0]));
            StartCoroutine(SpawnNotes(D4, noteSequence[2]));
            StartCoroutine(SpawnNotes(E4, noteSequence[4]));
            //spawn pro notes
            if (GameInfo.difficulty >= 2)
            {
                StartCoroutine(SpawnNotes(Cs4, noteSequence[1]));
                StartCoroutine(SpawnNotes(Ds4, noteSequence[3]));
                StartCoroutine(SpawnNotes(Fs4, noteSequence[6]));
                StartCoroutine(SpawnNotes(Gs4, noteSequence[8]));
                StartCoroutine(SpawnNotes(As4, noteSequence[10]));
                //spawn max notes
            }
        }

        yield return null;




    }




    private IEnumerator SpawnNotes(GameObject note, double[] sequence)
    {

        for (int i = 0; i < sequence.Length; i += 2)
        {
            Vector3 newPosition = new Vector3(note.transform.position.x, note.transform.position.y, note.transform.position.z + 1f);
            GameObject newNote = Instantiate(notePrefab, newPosition, Quaternion.identity);
            Note noteScript = newNote.GetComponent<Note>();
            noteScript.startTime = sequence[i];
            noteScript.endTime = sequence[i + 1];



        }

        yield break;
        //ends the coroutine
    }

    public void ImportNoteSequence(double[][] sequence)
    {
        noteSequence = sequence;

    }

    public void HandleKeyPress(int keyIndex, double hitTime, GameObject key)
    {
        //note hit times are in beats, but tolerances are in milliseconds
        

        double[] keySequence = noteSequence[keyIndex];
        for(int i=0; i<keySequence.Length; i+=2)
        {
            if (Mathf.Abs((float)(keySequence[i] - hitTime)) < (float) GameInfo.noteTolerances[GameInfo.noteTolerances.Length - 1] / 60000 * GameInfo.BPM)
            {
                double startTime = keySequence[i];
                double endTime = keySequence[i + 1];
                if (endTime - startTime > 1)
                {
                    KeyColor keyColor = key.GetComponent<KeyColor>();
                    if (keyColor != null)
                    {
                        keyColor.SetColor("hold");
                    }
                }
                else
                {
                    KeyColor keyColor = key.GetComponent<KeyColor>();
                    if (keyColor != null)
                    {
                        keyColor.SetColor("tap");
                    }
                }
                //set the color of the key based on the note type


                int noteIndex = GameInfo.noteTolerances.Length - 1;

                for (int j = GameInfo.noteTolerances.Length - 1; j >= 0; j--)
                {

                    //loop starts at most lenient tolerances and goes forward
                    if (Mathf.Abs((float)(keySequence[i] - hitTime)) <= (float) GameInfo.noteTolerances[j]  / 60000 * GameInfo.BPM)
                    {
                        noteIndex = j;
                    }
                }

                //calculate the note type based on the hit time

                GameInfo.score += GameInfo.scoreMultipliers[noteIndex];
                if (noteIndex > GameInfo.noteTolerances.Length - 3)
                {
                    GameInfo.combo++;

                }
                else
                {
                    GameInfo.combo = 0;
                    //reset combo if the note is hit too early or late
                    //this occurs when the note is hit with the "mediocre" or "abysmal" tolerances
                }

                scoreText.text = "Score: " + GameInfo.score;
                comboText.text = "Combo: " + GameInfo.combo;
                noteText.text = "" + GameInfo.noteTypes[noteIndex] + "";
                noteText.color = noteTextColors[noteIndex];
                //updates the text


                //note hit
            }
            else
            {
                KeyColor keyColor = key.GetComponent<KeyColor>();
                if (keyColor != null)
                {
                    keyColor.SetColor("pressed");
                }
            }
        }

    }
}
