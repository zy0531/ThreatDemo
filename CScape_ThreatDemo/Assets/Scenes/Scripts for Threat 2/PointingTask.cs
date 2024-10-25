using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PointingTask : MonoBehaviour
{
    
    public Transform threatPosition { get; set; }
    public Vector3 groundTruthDirection { get; set; }
    public float pointingError { get; set; }

    InputDevice rightcontroller;
    bool ButtonState;
    bool buttonDown_XRInput;

    [SerializeField] AudioSource TriggerAudioSource;
    [SerializeField] DataManager dataManager;
    string Path;
    string FileName;

    [SerializeField] TextMeshProUGUI pointingTaskInstructionTMP;

    // Start is called before the first frame update
    void Start()
    {
        //Find Right Controller
        var RightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, RightHandDevices);

        if (RightHandDevices.Count == 1)
        {
            rightcontroller = RightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", rightcontroller.name, rightcontroller.role.ToString()));
        }
        else if (RightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }

        // Record Data
        Path = dataManager.folderPath;
        FileName = dataManager.fileName;

        // record PointingPerformance
        RecordData.SaveData(Path, "Pointing",
          "Time" + ";"
        + "Trial" + ";"
        + "CameraPosition" + ";"
        + "ThreatPosition" + ";"
        + "PointingDirection" + ";"
        + "PointingError(in degrees)" + '\n');
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rightcontroller.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out ButtonState) && ButtonState) // using trigger button
        {          
            if (ColorGlobal.IsPointingTaskStarted && !ColorGlobal.IsPointingTaskFinished)
            {
                // calculate the pointing error
                Vector3 pointingDirection = this.transform.forward;
                pointingError = CalculatePointingError(threatPosition, pointingDirection);
                Debug.Log("--------------------pointingError------------------:" + pointingError);
                Debug.Log(ColorGlobal.IsPointingTaskFinished);

                // trigger press audio feedback
                TriggerAudioSource.Play();

                // change the pointing instruction to notify the participants
                pointingTaskInstructionTMP.text = "Your pointing selection was successful!";

                // record the pointing error
                RecordData.SaveData(Path, "Pointing",
                  DateTime.Now.ToString() + ";"
                + (ColorGlobal.trial) + ";"
                + Camera.main.transform.position.ToString() + ";"
                + threatPosition.position.ToString() + ";"
                + pointingDirection.ToString() + ";"
                + pointingError.ToString() + '\n');

                ColorGlobal.IsPointingTaskFinished = true;
            }
        }
    }

    public void SetThreatPosition(Transform ThreatPosition)
    {
        threatPosition = ThreatPosition;
    }

    public float CalculatePointingError(Transform ThreatPosition, Vector3 PointingDirection)
    {
        // ground truth
        groundTruthDirection = CalculateGroundTruthDirection(Camera.main.transform, ThreatPosition);
        groundTruthDirection = Vector3.ProjectOnPlane(groundTruthDirection, Vector3.up).normalized;//xz plane 

        // pointing direction
        PointingDirection = Vector3.ProjectOnPlane(PointingDirection, Vector3.up).normalized;//xz plane 

        // angle
        float angle = Vector3.Angle(groundTruthDirection, PointingDirection);

        return angle;
    }

    public Vector3 CalculateGroundTruthDirection(Transform pos1, Transform pos2)
    {
        Vector3 GroundTruthDirection = (pos2.position - pos1.position).normalized;

        return GroundTruthDirection;
    }


    string GetPreviousRouteName(string routeName)
    {
        return DecrementLastCharacterInString(routeName);
    }
    string DecrementLastCharacterInString(string s)
    {
        if (!string.IsNullOrEmpty(s) && char.IsDigit(s[s.Length - 1])) // Check if the string is not empty and the last character is a digit
        {
            char lastChar = s[s.Length - 1]; // Get the last character
            int lastDigit = lastChar - '0'; // Convert char to int
            if (lastDigit > 0) // Make sure it doesn't go below 0
            {
                lastDigit--; // Decrement the digit
            }
            return s.Substring(0, s.Length - 1) + lastDigit; // Return the string with the decremented digit
        }
        return s; // Return the original string if the last character is not a digit
    }
}
