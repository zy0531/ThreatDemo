using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;


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
    
    /// <summary>
    /// Route Position Information
    /// </summary>
    public Transform startPosition;
    public Transform ThreatTransform;
    public GameObject ThreatBuilding;
    public Transform endPosition;
}


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
        RecordData.SaveData(Path, FileName,
          "Time" + ";"
        + "RouteName" + ";"
        + "RoutenNumber" + ";"
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
        + "UsedTime" + ";"
        + "UsedTimeInRed" + ";"
        + "UsedTimeInYellow" + ";"
        + "Point" + '\n');
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
        }
            
        
        if (currentRoute_name != ColorGlobal.CurrentRoute)
        {
            //Record Data
            if (currentRoute_num > 0 && currentRoute_num < Routes.Count)
            {
                // float point = 100f - ColorGlobal.UsedTime / 60f * 1f - ColorGlobal.UsedTimeInRed * 3f - ColorGlobal.UsedTimeInYellow * 1f;
                float point = ColorGlobal.Point;
                ColorGlobal.Point_TrialEnd = point;

                RecordData.SaveData(Path, FileName,
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
                    + ColorGlobal.UsedTime.ToString("f3") + ";"
                    + ColorGlobal.UsedTimeInRed.ToString("f3") + ";"
                    + ColorGlobal.UsedTimeInYellow.ToString("f3") + ";"
                    + point.ToString("f3")
                    + '\n');
                
                Debug.Log("currentRoute_name: ********** " + currentRoute_name);
                // Debug.Log("ColorGlobal.CurrentRoute: **********" + ColorGlobal.CurrentRoute);
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
                if (route.ActivateFOVCue) cueManager.InactivateFOVCue();
                if (route.ActivateLaserCue) cueManager.InactivateLaserCue();
                if (route.ActivateHighlightCue) cueManager.InactivateHighlightCue();
                if (route.ActivateTextCue) cueManager.InactivateTextCue();

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

                // Update currentRoute info;
                currentRoute_num++;
                currentRoute_name = ColorGlobal.CurrentRoute;
            }
            else
            {
                Debug.Log("End of Routes (RouteManager) !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                StartCoroutine(Quit.WaitQuit(5));
            }
        }
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
}

