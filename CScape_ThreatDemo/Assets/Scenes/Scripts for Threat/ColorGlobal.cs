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

    public static bool IsPractice = true; // change from mandatory practice first (false) -> optional practice (true)
    public static bool FirstTrial = false;
    public static bool IsBreak = false;

    public static int trial = 0;

    public static bool IsPointingTaskFinished = false;
    public static bool IsPointingTaskStarted = false;
    public static bool IsQuestionnaireStarted = false;
}
