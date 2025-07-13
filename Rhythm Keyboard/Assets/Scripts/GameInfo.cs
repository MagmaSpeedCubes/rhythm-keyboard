using UnityEngine;

public class GameInfo
{

    public const bool debugMode = true;
    public static readonly string[] noteTypes = { "Perfect", "Incredible", "Fantastic", "Great", "Good", "Mediocre", "Missed" };
    public static readonly int[] scoreMultipliers = { 50, 30, 20, 12, 7, -5, -20 };
    public static readonly int[] noteTolerances = { 20, 30, 50, 100, 200, 500, 1000 };
    public static readonly double levelStartDelay = 3;
    public static int selectedLevel = 0;
    public static int difficulty = 0;
    //0 = Base, 1 = Pro, 2 = Max
    public static double BPM = 40;

    public static double noteSpeed = 4;
    public static double initialBPM = 80;
    //initialBPM is the BPM of the level before any modifiers are applied
    public static double beatsElapsed = 0;
    public static double levelLength = 0;
    public static int levelPerfectScore = 0;

    public static bool gameActive = false;


    public static int score = 0;
    public static int combo = 0;
}
