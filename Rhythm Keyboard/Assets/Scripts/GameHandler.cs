using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

    public void StartGame()
    {
        GameInfo.gameActive = true;
        GameInfo.beatsElapsed = 0;
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

        



    }




    private IEnumerator SpawnNotes(GameObject note, double[] sequence)
    {

        for (int i = 0; i < sequence.Length; i += 2)
        {
            GameObject newNote = Instantiate(notePrefab, note.transform.position, Quaternion.identity);
            Note noteScript = newNote.GetComponent<Note>();
            noteScript.startTime = sequence[i];
            noteScript.endTime = sequence[i + 1];

            Debug.Log("Spawned note " + note.name + " from time " + noteScript.startTime + " to " + noteScript.endTime);
            //spawns each note 
        }

        yield break;
        //ends the coroutine
    }

    public void ImportNoteSequence(double[][] sequence)
    {
        noteSequence = sequence;
    
    }
}
