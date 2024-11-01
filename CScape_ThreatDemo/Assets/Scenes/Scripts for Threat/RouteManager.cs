using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using TMPro;


public enum Level { One, Two, Three };

[System.Serializable]
public struct Threat
{
    /// <summary>
    /// Threat Level
    /// </summary>
    public Level level;
    public float Red_ViewDis;
    public float Red_FOV;
    public float Yellow_ViewDis;
    public float Yellow_FOV;
    public float Green_ViewDis;
    public float Green_FOV;
    [SerializeField] public GameObject TriggerRedZone;
    [SerializeField] public GameObject TriggerYellowZone;
    [SerializeField] public GameObject TriggerGreenZone;

    /// <summary>
    /// Cue Type (can select multiple)
    /// </summary>
    public bool ActivateFOVCue;
    public bool ActivateHighlightCue;
    public bool ActivateTextCue;
    public bool ActivateLaserCue;
    public bool ActivateScreenTintCue;
    public bool ActivateGroundCircleCue;
    public bool ActivateMiniMapGroundCircleCue;

    /// <summary>
    /// Route Position Information
    /// </summary>
    public Transform startPosition;
    public Transform ThreatTransform;
    public GameObject ThreatBuilding;
    public Transform endPosition;
}

public enum ExperimentQuestionnaire { QuestionnaireVR_Pointing, QuestionnaireDesktop_Pointing, None };


public class RouteManager : MonoBehaviour
{

    public List<Threat> Routes;
    //= new List<Threat> { };

    string currentRoute_name;
    int currentRoute_num;
    Threat route;

    [SerializeField] CueManager cueManager;
    [SerializeField] DataManager dataManager;
    [SerializeField] TimerThreat timer;
    public ExperimentQuestionnaire isQuestionnaireAndPointingTask;
    [SerializeField] PointingTask pointingTask;

    [SerializeField] GameObject mainComponent;
    [SerializeField] GameObject questionnaireComponent;
    [SerializeField] QuestionnaireDataManager questionnaireDataManager;

    [SerializeField] GameObject ARSimulationPlane;
    [SerializeField] GameObject headsetTakeOffInstruction;
    [SerializeField] GameObject pointingTaskInstruction;
    [SerializeField] TextMeshProUGUI pointingTaskInstructionTMP;
    [SerializeField] GameObject pointingTaskRayVisualization;
    [SerializeField] GameObject timerInterface;
    

    /// <summary>
    /// 1st for the first two questions before the pointing, 2nd for the pointing, 3rd for the one question after the pointing
    /// </summary>
    int instructionNum = 0; 

    string Path;
    string FileName;

    void Start()
    {
        currentRoute_name = ColorGlobal.CurrentRoute;
        currentRoute_num = 0;
        Debug.Log("Routes.Count: " + Routes.Count);

        // Disable All Routes
        for (int i = 0; i < Routes.Count; i++)
        {
            Routes[i].startPosition.transform.parent.gameObject.SetActive(false);
        }
        Debug.Log("Disabled All Routes");
        // Record Data
        Path = dataManager.folderPath;
        FileName = dataManager.fileName;

        // record summary in a separate file
        RecordData.SaveData(Path, "Summary",
          "Time" + ";"
        + "RouteName" + ";"
        + "RouteNumber" + ";"
        + "StartPosition" + ";"
        + "ThreatPosition" + ";"
        + "ThreatOrientation(quaternion)" + ";"
        + "ThreatOrientation(eulerAngles)" + ";"
        + "EndPosition" + ";"
        + "Level" + ";"
        + "Red_ViewDis" + ";"
        + "Red_FOV" + ";"
        + "Yellow_ViewDis" + ";"
        + "Yellow_FOV" + ";"
        + "Green_ViewDis" + ";"
        + "Green_FOV" + ";"
        + "FOVCue" + ";"
        + "LaserCue" + ";"
        + "HighlightCue" + ";"
        + "TextCue" + ";"
        + "ScreenTintCue" + ";"
        + "GroundCircleCue" + ";"
        + "MiniMapGroundCircleCue" + ";"
        + "UsedTime" + ";"
        + "UsedTimeInRed" + ";"
        + "UsedTimeInYellow" + ";"
        + "Point" + '\n');

        // record trajectory data in a separate file
        RecordData.SaveData(Path, "TrajectoryData",
          "LogTime" + ";"
        + "TimeSinceGameStart" + ";"
        + "RouteName" + ";"
        + "RouteNumber" + ";"
        + "CameraPosition" + ";"
        + "CameraForward" + ";"
        + "CameraRotation (in quaternion)" + ";"
        + "CameraRotation (in eulerAngles)" + '\n');
    }

    void Update()
    {
        // if teleport to the staring position by clicking the trigger button -> activate route[0]
        if(ColorGlobal.FirstTrial)
        {
            Routes[0].startPosition.transform.parent.gameObject.SetActive(true);
            ColorGlobal.FirstTrial = false;
            // Disable Movement Control
            ColorGlobal.IsMovement = false;

            // Inactivate previous AR Cue
            InactivatePreviousARCue();

            // Reset Timer
            timer.SetTimerOff();
            ColorGlobal.UsedTimeInRed = 0;
            ColorGlobal.UsedTimeInYellow = 0;
            ColorGlobal.UsedTime = 0;

            // Disable Movement Control
            ColorGlobal.IsMovement = false;

            // Do not reset Point

            // Set New route
            route = Routes[currentRoute_num];

            // Set New Trigger Zone
            SetTriggerZone(route);

            // Activate Selected Cue
            ActivateARCue();

            Debug.Log("route.ActivateGroundCircleCue:" + route.ActivateGroundCircleCue);
            Debug.Log("route.ActivateMiniMapGroundCircleCue:" + route.ActivateMiniMapGroundCircleCue);
        }
            
        
        if (currentRoute_name != ColorGlobal.CurrentRoute)
        {
            if(!ColorGlobal.IsQuestionnaireStarted)
            {
                //Record Data
                if (currentRoute_num > 0 && currentRoute_num <= Routes.Count)
                {
                    float point = ColorGlobal.Point;

                    ColorGlobal.Point_TrialEnd = point;


                    // record summary data in a separate file
                    RecordData.SaveData(Path, "Summary",
                          DateTime.Now.ToString() + ";"
                        + currentRoute_name.ToString() + ";"
                        + currentRoute_num.ToString() + ";"
                        + route.startPosition.position.ToString() + ";"
                        + route.ThreatTransform.position.ToString() + ";"
                        + route.ThreatTransform.rotation.ToString() + ";"
                        + route.ThreatTransform.eulerAngles.ToString() + ";"
                        + route.endPosition.position.ToString() + ";"
                        + route.level + ";"
                        + route.Red_ViewDis + ";"
                        + route.Red_FOV + ";"
                        + route.Yellow_ViewDis + ";"
                        + route.Yellow_FOV + ";"
                        + route.Green_ViewDis + ";"
                        + route.Green_FOV + ";"
                        + route.ActivateFOVCue + ";"
                        + route.ActivateLaserCue + ";"
                        + route.ActivateHighlightCue + ";"
                        + route.ActivateTextCue + ";"
                        + route.ActivateScreenTintCue + ";"
                        + route.ActivateGroundCircleCue + ";"
                        + route.ActivateMiniMapGroundCircleCue + ";"
                        + ColorGlobal.UsedTime.ToString("f3") + ";"
                        + ColorGlobal.UsedTimeInRed.ToString("f3") + ";"
                        + ColorGlobal.UsedTimeInYellow.ToString("f3") + ";"
                        + point.ToString("f3")
                        + '\n');

                    Debug.Log("currentRoute_name: ********** " + currentRoute_name);
                    Debug.Log("ColorGlobal.CurrentRoute: **********" + ColorGlobal.CurrentRoute);
                    Debug.Log("currentRoute_num: **********" + currentRoute_num);
                    Debug.Log("ColorGlobal.UsedTime: ********** " + ColorGlobal.UsedTime);
                    Debug.Log("ColorGlobal.UsedTimeInRed: ********** " + ColorGlobal.UsedTimeInRed);
                    Debug.Log("ColorGlobal.UsedTimeInYellow: ********** " + ColorGlobal.UsedTimeInYellow);
                    Debug.Log("point: ********** " + point);
                }
                //Record Data End


                if (currentRoute_num < Routes.Count)
                {
                    // Inactivate previous AR Cue
                    InactivatePreviousARCue();

                    // Reset Timer
                    timer.SetTimerOff();
                    ColorGlobal.UsedTimeInRed = 0;
                    ColorGlobal.UsedTimeInYellow = 0;
                    ColorGlobal.UsedTime = 0;

                    // Disable Movement Control
                    ColorGlobal.IsMovement = false;

                    // Do not reset Point

                    // Set New route
                    route = Routes[currentRoute_num];

                    // Set New Trigger Zone
                    SetTriggerZone(route);

                    // Activate Selected Cue
                    ActivateARCue();

                    // Activate AR Lens
                    ARSimulationPlane.SetActive(true);
                    // Activate Timer Interface
                    timerInterface.SetActive(true);

                    // Update currentRoute info;
                    currentRoute_num++;
                    currentRoute_name = ColorGlobal.CurrentRoute;

                    // Update Trial Number;
                    ColorGlobal.trial = currentRoute_num;
                }
                else
                {
                    Debug.Log("End of Routes (RouteManager) !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    StartCoroutine(Quit.WaitQuit(0));
                }
            }
            else // If the Questionnaire session start
            {
                // Inactivate AR Lens
                ARSimulationPlane.SetActive(false);
                // Inactivate Timer Interface
                timerInterface.SetActive(false);
                // Inactivate previous AR Cue
                InactivatePreviousARCue();

                // If set Questionnaire in VR and Pointing Task after each segment of routes
                if (isQuestionnaireAndPointingTask == ExperimentQuestionnaire.QuestionnaireVR_Pointing)
                {
                    Debug.Log("questionnaireDataManager.currentIndex" + questionnaireDataManager.currentIndex);
                    // finish the 1st and 2nd question
                    if (questionnaireDataManager.currentIndex < 2)
                    {
                        GoToLobby();
                    }

                    // pointing task & the 3rd question
                    if (questionnaireDataManager.currentIndex == 2)
                    {
                        // if not finish the pointing task, teleport back to the route -> finish the pointing task
                        if (!ColorGlobal.IsPointingTaskFinished)
                        {
                            GoToEnvironment();
                            pointingTaskInstruction.SetActive(true);
                            pointingTask.SetThreatPosition(route.ThreatTransform);
                        }
                        // if already finish the pointing task -> go back to lobby, finish the 3rd question
                        else
                        {
                            pointingTaskInstruction.SetActive(false);
                            GoToLobby();
                        }
                    }

                    // already finished all trials -> teleport back to the route, ready to start the next trial
                    if (questionnaireDataManager.currentIndex > 2)
                    {
                        ColorGlobal.IsPointingTaskFinished = false;
                        ColorGlobal.IsQuestionnaireStarted = false;
                        questionnaireDataManager.ResetQuestionIndex();
                        GoToEnvironment();
                    }
                }
                // If set Questionnaire in desktop/verbal and Pointing Task after each segment of routes
                else if (isQuestionnaireAndPointingTask == ExperimentQuestionnaire.QuestionnaireDesktop_Pointing)
                {
                    if (instructionNum == 0)
                    {
                        headsetTakeOffInstruction.SetActive(false);
                        pointingTaskInstruction.SetActive(false);
                    }
                    
                    if (instructionNum == 1)
                    {
                        headsetTakeOffInstruction.SetActive(true);
                    }
                        
                    if (instructionNum == 2)
                    {
                        ColorGlobal.IsPointingTaskStarted = true;
                        headsetTakeOffInstruction.SetActive(false);
                        pointingTaskInstruction.SetActive(true);
                        pointingTask.SetThreatPosition(route.ThreatTransform);
                        pointingTaskRayVisualization.SetActive(true);
                    }
                    if (instructionNum > 2)
                    {
                        ColorGlobal.IsPointingTaskStarted = false;
                        ColorGlobal.IsPointingTaskFinished = false;
                        ColorGlobal.IsQuestionnaireStarted = false;

                        headsetTakeOffInstruction.SetActive(false);
                        pointingTaskInstruction.SetActive(false);
                        pointingTaskRayVisualization.SetActive(false);

                        instructionNum = 0;
                        pointingTaskInstructionTMP.text = "Please point to where you believe the threat was located and press the trigger button to confirm your answer. ";
                    }
                }
                // If no task after each segment of routes
                else if (isQuestionnaireAndPointingTask == ExperimentQuestionnaire.None)
                {
                    ColorGlobal.IsQuestionnaireStarted = false;
                }
            }
        }




        // keyboard for proceed the instructions between trials
        if (Input.GetKeyUp(KeyCode.N))
        {
            instructionNum += 1;
        }
    }

    void FixedUpdate()
    {
        //Record Trajectory Data
        if (currentRoute_num > 0 && currentRoute_num <= Routes.Count)
        {
            if (ColorGlobal.IsMovement)
            {
                RecordData.SaveData(Path, "TrajectoryData",
                (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString() + ";"
                + Time.fixedTime.ToString() + ";" // The time since the last FixedUpdate started (Read Only). This is the time in seconds since the start of the game.
                + currentRoute_name.ToString() + ";"
                + currentRoute_num.ToString() + ";"
                + Camera.main.transform.position + ";"
                + Camera.main.transform.forward + ";"
                + Camera.main.transform.rotation + ";"
                + Camera.main.transform.eulerAngles
                + '\n');
            }
        }
        //Record Trajectory Data End
    }

    void SetTriggerZone(Threat route)
    {
        /// ********** Initialize Trigger Zone ********** ///
        var TriggerRed = route.TriggerRedZone.GetComponent<TriggerColor>();
        var TriggerYellow = route.TriggerYellowZone.GetComponent<TriggerColor>();
        var TriggerGreen = route.TriggerGreenZone.GetComponent<TriggerColor>();


        // Map to the ground & add a small offset on y axis
        TriggerRed.SetOrigin(new Vector3(route.ThreatTransform.position.x, 0.17f, route.ThreatTransform.position.z));
        TriggerYellow.SetOrigin(new Vector3(route.ThreatTransform.position.x, 0.16f, route.ThreatTransform.position.z));
        TriggerGreen.SetOrigin(new Vector3(route.ThreatTransform.position.x, 0.15f, route.ThreatTransform.position.z));

        switch (route.level)
        {
            case Level.Three:
                TriggerRed.SetFOV(route.Red_FOV);
                TriggerRed.SetViewDistance(route.Red_ViewDis);
                TriggerRed.SetDirection(route.ThreatTransform.eulerAngles);
                TriggerRed.GenerateTriggerZone();

                TriggerYellow.SetFOV(route.Yellow_FOV);
                TriggerYellow.SetViewDistance(route.Yellow_ViewDis);
                TriggerYellow.SetDirection(route.ThreatTransform.eulerAngles);
                TriggerYellow.GenerateTriggerZone();

                TriggerGreen.SetFOV(route.Green_FOV);
                TriggerGreen.SetViewDistance(route.Green_ViewDis);
                TriggerGreen.SetDirection(route.ThreatTransform.eulerAngles);
                TriggerGreen.GenerateTriggerZone();
                break;

            case Level.Two:
                TriggerRed.SetFOV(route.Red_FOV);
                TriggerRed.SetViewDistance(route.Red_ViewDis);
                TriggerRed.SetDirection(route.ThreatTransform.eulerAngles);
                TriggerRed.GenerateTriggerZone();

                TriggerYellow.SetFOV(route.Yellow_FOV);
                TriggerYellow.SetViewDistance(route.Yellow_ViewDis);
                TriggerYellow.SetDirection(route.ThreatTransform.eulerAngles);
                TriggerYellow.GenerateTriggerZone();

                TriggerGreen.SetFOV(0f);
                TriggerGreen.SetViewDistance(0f);
                break;

            case Level.One:
                TriggerRed.SetFOV(route.Red_FOV);
                TriggerRed.SetViewDistance(route.Red_ViewDis);
                TriggerRed.SetDirection(route.ThreatTransform.eulerAngles);
                TriggerRed.GenerateTriggerZone();

                TriggerYellow.SetFOV(0f);
                TriggerYellow.SetViewDistance(0f);

                TriggerGreen.SetFOV(0f);
                TriggerGreen.SetViewDistance(0f);
                break;

            default:
                break;

        }
        /// ********** Initialize Trigger Zone End ********** ///
    }


    // Adding Bonus points (Obsolete)
    float AddBonusPoints(float usedTime)
    {
        // if under 50s
        if (usedTime <= 50f)
        {
            return 25f + (50f - usedTime) * 4f;
        }
        // else if under 60s (i.e., 50-60s)
        else if (usedTime <= 60f)
        {
            return (60f - usedTime) * 2.5f;
        }
        // else over 60s
        else
        {
            return 0f;
        }
    }


    void InactivatePreviousARCue()
    {
        if (route.ActivateFOVCue) cueManager.InactivateFOVCue();
        if (route.ActivateLaserCue) cueManager.InactivateLaserCue();
        if (route.ActivateHighlightCue) cueManager.InactivateHighlightCue();
        if (route.ActivateTextCue) cueManager.InactivateTextCue();
        if (route.ActivateScreenTintCue) cueManager.InactivateScreenTintCue();
        if (route.ActivateGroundCircleCue) cueManager.InactivateGroundCircleCue();
        if (route.ActivateMiniMapGroundCircleCue) cueManager.InactivateMiniMapGroundCircleCue();
    }

    void ActivateARCue()
    {
        if (route.ActivateFOVCue)
        {
            Debug.Log("ActivateFOVCue");
            cueManager.InitializeFOVCue(route.level, route.ThreatTransform, route.Red_FOV, route.Red_ViewDis, route.Yellow_FOV, route.Yellow_ViewDis, route.Green_FOV, route.Green_ViewDis);
        }
        if (route.ActivateLaserCue)
        {
            Debug.Log("ActivateLaserCue");
            cueManager.InitializeLaserCue(route.ThreatTransform, route.Red_FOV, route.Red_ViewDis);
        }
        if (route.ActivateHighlightCue)
        {
            Debug.Log("ActivateHighlightCue");
            cueManager.InitializeHighlightCue(route.ThreatTransform, route.ThreatBuilding);
        }
        if (route.ActivateTextCue)
        {
            Debug.Log("ActivateTextCue");
            cueManager.InitializeTextCue(route.ThreatTransform);
        }
        if (route.ActivateScreenTintCue)
        {
            Debug.Log("ActivateScreenTintCue");
            cueManager.InitializeScreenTintCue();
        }
        if (route.ActivateGroundCircleCue)
        {
            Debug.Log("ActivateGroundCircleCue");
            cueManager.InitializeGroundCircleCue(route.level, route.ThreatTransform, route.Red_ViewDis, route.Yellow_ViewDis, route.Green_ViewDis);
        }
        if (route.ActivateMiniMapGroundCircleCue)
        {
            Debug.Log("ActivateMiniMapGroundCircleCue");
            cueManager.InitializeMiniMapGroundCircleCue(route.level, route.ThreatTransform, route.Red_ViewDis, route.Yellow_ViewDis, route.Green_ViewDis);
        }
    }


    void GoToEnvironment()
    {
        if (questionnaireComponent.activeSelf == true)
            questionnaireComponent.SetActive(false);
        if (mainComponent.activeSelf == false)
            mainComponent.SetActive(true);
    }
    void GoToLobby()
    {
        if (mainComponent.activeSelf == true)
            mainComponent.SetActive(false);
        if (questionnaireComponent.activeSelf == false)
            questionnaireComponent.SetActive(true);
    }
}

