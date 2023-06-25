using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorGlobal
{
    public static string CurrentRoute = "";

    public static bool InRedArea = false;
    public static bool InYellowArea = false;
    public static bool InGreenArea = true;

    public static float UsedTimeInRed = 0;
    public static float UsedTimeInYellow = 0;
    public static float UsedTime = 0;

    public static float Point = 0;
    public static float Point_TrialEnd = 0;

    public static bool IsMovement = false;

    public static bool IsPractice = false;
    public static bool FirstTrial = false;

    public static int trial = 0;
}
