using UnityEngine;

public class Note : MonoBehaviour
{

    private static readonly string[] noteTypes = { "Perfect", "Incredible", "Fantastic", "Great", "Good", "Mediocre", "Abysmal" };
    private static readonly int[] scoreMultipliers = { 50, 20, 5, 2, 1, 0, -5 };
    private static readonly int[] noteTolerances = { 0, 10, 20, 50, 100, 200, 999999 };
    //adjust these later based on gameplay testing
    private int earlyTolerance = 1;
    private double lateTolerance = 0.25;
    private int startTime;
    private bool isHoldNote;
    private int endTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void SetNoteLength()
    {
        float duration = endTime - startTime;
        if (duration < 1) { duration = 1; } // Prevent zero or negative scale
        if (duration == 1) { isHoldNote = false; } // If the duration is 1, it's not a hold note
        else { isHoldNote = true; }

        Vector3 scale = transform.localScale;
        scale.y = duration;
        transform.localScale = scale;
    }


    public int toleranceCalculation(int hitTime, int releaseTime, int difficulty)
    {
        int bestQualifyingNote = 0;

        int timeDifference = hitTime - startTime;
        if (timeDifference < 0)
        {
            for (int i = 0; i < noteTolerances.Length; i++)
            {
                if (-timeDifference <= noteTolerances[i] * earlyTolerance)
                {
                    if (bestQualifyingNote < i)
                    {
                        bestQualifyingNote = i;
                    }
                }
            }
        }
        else if (timeDifference > 0)
        {
            for (int i = 0; i < noteTolerances.Length; i++)
            {
                if (-timeDifference <= noteTolerances[i] * lateTolerance)
                {
                    if (bestQualifyingNote < i)
                    {
                        bestQualifyingNote = i;
                    }
                }
            }
        }

        if (!isHoldNote)
        {
            return bestQualifyingNote;
        }

        timeDifference = releaseTime - endTime;

        if (timeDifference < 0)
        {
            for (int i = 0; i < noteTolerances.Length; i++)
            {
                if (-timeDifference <= noteTolerances[i] * earlyTolerance)
                {
                    if (bestQualifyingNote < i)
                    {
                        bestQualifyingNote = i;
                    }
                }
            }
        }
        else if (timeDifference > 0)
        {
            for (int i = 0; i < noteTolerances.Length; i++)
            {
                if (-timeDifference <= noteTolerances[i] * lateTolerance)
                {
                    if (bestQualifyingNote < i)
                    {
                        bestQualifyingNote = i;
                    }
                }
            }
        }

        return bestQualifyingNote;



    }
    
    
}
