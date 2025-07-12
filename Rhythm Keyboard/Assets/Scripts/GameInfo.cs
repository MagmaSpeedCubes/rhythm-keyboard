using UnityEngine;

public class GameInfo
{

    public static readonly double levelStartDelay = 3;
    public static int selectedLevel = 0;
    public static int difficulty = 0;
    //0 = Base, 1 = Pro, 2 = Max
    public static int BPM = 40;

    public static double noteSpeed = 2;
    public static int initialBPM = 40;
    //initialBPM is the BPM of the level before any modifiers are applied
    public static double beatsElapsed = 0;

    public static bool gameActive = false;
}
