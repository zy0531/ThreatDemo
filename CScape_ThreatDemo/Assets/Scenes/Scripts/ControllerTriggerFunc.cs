using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerTriggerFunc : MonoBehaviour
{
    public int LandmarkNum;
    public TeleportInPointingTask task;
    public ControllerRay controllerRay;
    [SerializeField] DataManager dataManager;
    [SerializeField] AudioSource ClickAudio;
    [SerializeField] AudioSource FinishText;
    [SerializeField] AudioSource FinishSoundEffect;

    int TriggerNum = 0; 
    int TrialNum = 0;
    bool buttonDown_XRInput = false;
    
    InputDevice device;
    bool triggerValue;

    string Path;
    string FileName;

    Vector3 estDirection, groundtruthDirection;
    string referencelandmark, displaylandmark;

    void Start()
    {
        //Find Right Controller
        var RightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, RightHandDevices);

        if (RightHandDevices.Count == 1)
        {
            device = RightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }
        else if (RightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }


        //Record Data -- First Line
        Path = dataManager.folderPath;
        FileName = dataManager.fileName;
        //RecordData.SaveData(Path, FileName,
        //      "Time" + ";"
        //    + "TrialNum" + ";"
        //    + "TriggerNum" + ","
        //    + "Referencelandmark" + ";"
        //    + "Displaylandmark" + ", "
        //    + "GroundTruthDirection" + "; "
        //    + "EstDirection" + "; "
        //    + "Angle" + '\n');
        ////Record the task starting time
        //RecordData.SaveData(Path, FileName,
        //      DateTime.Now.ToString() + ";"
        //                + ";"
        //                + ";"
        //                + ";"
        //                + ";"
        //                + ";"
        //                + ";"
        //                + '\n');
    }

    void Update()
    {
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            //Debug.Log("Trigger button is pressed.");
            //Debug.Log("triggerValue: " + triggerValue);
            if(!buttonDown_XRInput)
            {
                // Button is pressed
                Debug.Log("buttonDown_XRInput is pressed");
                buttonDown_XRInput = true;
            }
            else
            {
                // Button is held down
                Debug.Log("buttonDown_XRInput is held");
            }
        }
        else if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) && buttonDown_XRInput)
        {
            // Button is released
            Debug.Log("buttonDown_XRInput is released");
            ClickAudio.Play(0);

            /// 
            /// Order cannot be changed here 
            /// 
            if (!task.taskFinish)
            {
                //Log estimated direction for the previous trial
                if (TriggerNum >= 1 && TriggerNum % LandmarkNum != 0)
                {
                    controllerRay.SetEstimatedDirection();
                    estDirection = controllerRay.EstimatedDirection;
                    estDirection = Vector3.ProjectOnPlane(estDirection, new Vector3(0, 1, 0));//xz plane

                    Debug.Log("groundtruthDirectionRead: " + groundtruthDirection.ToString("f3"));
                    Debug.Log("estimatedDirectionRead: " + estDirection.ToString("f3"));

                    //Calculate Angle between "groundtruthDirection" and "estDirection"
                    float angle = Vector3.Angle(estDirection, groundtruthDirection);
                    Debug.Log(angle.ToString("f3"));

                    ////Record Data
                    //RecordData.SaveData(Path, FileName,
                    //      DateTime.Now.ToString() + ";"
                    //    + TrialNum.ToString() + ";"
                    //    + TriggerNum.ToString() + ";"
                    //    + referencelandmark + ";"
                    //    + displaylandmark + ";"
                    //    + groundtruthDirection.ToString("f3") + ";"
                    //    + estDirection.ToString("f3") + ";"
                    //    + angle.ToString("f3") + '\n');

                    //Trial Num
                    TrialNum++;
                }

                //Trigger Num
                Debug.Log("TriggerNum: " + TriggerNum);

                //Get landmark name & ground truth direction
                task.CallPointingTask();
                referencelandmark = task.referenceLandmark_name;
                displaylandmark = task.displayLandmark_name;
                Debug.Log("referencelandmark: " + referencelandmark);
                Debug.Log("displaylandmark: " + displaylandmark);
                groundtruthDirection = task.GroundTruthDirection;
                groundtruthDirection = Vector3.ProjectOnPlane(groundtruthDirection, new Vector3(0, 1, 0));//xz plane

                //Update Trigger Num
                TriggerNum++;
            }

            else
            {
                FinishText.Play();
                FinishSoundEffect.Play();
                StartCoroutine(Quit.WaitQuit(6));
            }
            buttonDown_XRInput = false;
        }
    }
}
