using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CueManager : MonoBehaviour
{

    /// <summary>
    /// FOV Cue
    /// </summary>
    //[SerializeField] public bool ActivateFOVCue;
    [SerializeField] GameObject FOVCue;

    /// <summary>
    /// Laser Cue
    /// </summary>
    //[SerializeField] public bool ActivateLaserCue;
    [SerializeField] GameObject LaserCue;

    /// <summary>
    /// Building Highlight Cue
    /// </summary>
    //[SerializeField] public bool ActivateHighlightCue;
    [SerializeField] GameObject HighlightCue;

    /// <summary>
    /// Text Cue
    /// </summary>
    //[SerializeField] public bool ActivateTextCue;
    [SerializeField] GameObject TextCue;


    // Start is called before the first frame update
    void Start()
    {
        // Set Trigger
        //TriggerRed.GetComponent<SphereCollider>().radius = viewDistance_L1_Red;
        //TriggerRed.GetComponent<SphereCollider>().center = new Vector3(threatTransform.position.x, 0, threatTransform.position.z);
        //TriggerYellow.GetComponent<SphereCollider>().radius = viewDistance_L2_Yellow;
        //TriggerYellow.GetComponent<SphereCollider>().center = new Vector3(threatTransform.position.x, 0, threatTransform.position.z);
        //TriggerGreen.GetComponent<SphereCollider>().radius = viewDistance_L3_Green;
        //TriggerGreen.GetComponent<SphereCollider>().center = new Vector3(threatTransform.position.x, 0, threatTransform.position.z);

        ///// ********** Initialize Trigger Zone ********** ///
        //var TriggerRed = TriggerRedZone.GetComponent<TriggerColor>();
        //var TriggerYellow = TriggerYellowZone.GetComponent<TriggerColor>();
        //var TriggerGreen = TriggerGreenZone.GetComponent<TriggerColor>();

        //// Map to the ground & add a small offset on y axis
        //TriggerRed.SetOrigin(new Vector3(threatTransform.position.x, 0.20f, threatTransform.position.z));
        //TriggerYellow.SetOrigin(new Vector3(threatTransform.position.x, 0.18f, threatTransform.position.z));
        //TriggerGreen.SetOrigin(new Vector3(threatTransform.position.x, 0.16f, threatTransform.position.z));

        //switch (level)
        //{
        //    case 3:
        //        TriggerRed.SetFOV(fov_L1_Red);
        //        TriggerRed.SetViewDistance(viewDistance_L1_Red);
        //        TriggerYellow.SetFOV(fov_L2_Yellow);
        //        TriggerYellow.SetViewDistance(viewDistance_L2_Yellow);
        //        TriggerGreen.SetFOV(fov_L3_Green);
        //        TriggerGreen.SetViewDistance(viewDistance_L3_Green);
        //        break;

        //    case 2:
        //        TriggerRed.SetFOV(fov_L1_Red);
        //        TriggerRed.SetViewDistance(viewDistance_L1_Red);
        //        TriggerYellow.SetFOV(fov_L2_Yellow);
        //        TriggerYellow.SetViewDistance(viewDistance_L2_Yellow);
        //        TriggerGreen.SetFOV(0f);
        //        TriggerGreen.SetViewDistance(0f);
        //        break;

        //    case 1:
        //        TriggerRed.SetFOV(fov_L1_Red);
        //        TriggerRed.SetViewDistance(viewDistance_L1_Red);
        //        TriggerYellow.SetFOV(0f);
        //        TriggerYellow.SetViewDistance(0f);
        //        TriggerGreen.SetFOV(0f);
        //        TriggerGreen.SetViewDistance(0f);
        //        break;

        //    default:
        //        break;

        //}
        ///// ********** Initialize Trigger Zone End ********** ///



        ///// ********** Initialize FOV Cue ********** ///
        //    var FOVCue_Red = FOVCue.transform.GetChild(0).GetComponent<FieldOfView>();
        //    var FOVCue_Yellow = FOVCue.transform.GetChild(1).GetComponent<FieldOfView>();
        //    var FOVCue_Green = FOVCue.transform.GetChild(2).GetComponent<FieldOfView>();
        //    Debug.Log(FOVCue_Yellow);

        //    // Map to the ground & add a small offset on y axis
        //    FOVCue_Red.SetOrigin(new Vector3(threatTransform.position.x, 0.20f, threatTransform.position.z));
        //    FOVCue_Yellow.SetOrigin(new Vector3(threatTransform.position.x, 0.18f, threatTransform.position.z));
        //    FOVCue_Green.SetOrigin(new Vector3(threatTransform.position.x, 0.16f, threatTransform.position.z));

        //    switch (level)
        //    {
        //        case 3:
        //            FOVCue_Red.SetFOV(fov_L1_Red);
        //            FOVCue_Red.SetViewDistance(viewDistance_L1_Red);
        //            FOVCue_Yellow.SetFOV(fov_L2_Yellow);
        //            FOVCue_Yellow.SetViewDistance(viewDistance_L2_Yellow);
        //            FOVCue_Green.SetFOV(fov_L3_Green);
        //            FOVCue_Green.SetViewDistance(viewDistance_L3_Green);
        //            break;

        //        case 2:
        //            FOVCue_Red.SetFOV(fov_L1_Red);
        //            FOVCue_Red.SetViewDistance(viewDistance_L1_Red);
        //            FOVCue_Yellow.SetFOV(fov_L2_Yellow);
        //            FOVCue_Yellow.SetViewDistance(viewDistance_L2_Yellow);
        //            FOVCue_Green.SetFOV(0f);
        //            FOVCue_Green.SetViewDistance(0f);
        //        break;

        //        case 1:
        //            FOVCue_Red.SetFOV(fov_L1_Red);
        //            FOVCue_Red.SetViewDistance(viewDistance_L1_Red);
        //            FOVCue_Yellow.SetFOV(0f);
        //            FOVCue_Yellow.SetViewDistance(0f);
        //            FOVCue_Green.SetFOV(0f);
        //            FOVCue_Green.SetViewDistance(0f);
        //        break;

        //        default:
        //            break;

        //    }
        ///// ********** Initialize FOV Cue End ********** ///



       
        /// 

        ///// ********** Initialize Laser Cue ********** ///
        //var laser = LaserCue.GetComponent<Laser>();
        //laser.SetFOV(fov_L1_Red);
        //laser.SetViewDistance(viewDistance_L1_Red);
        ///// ********** Initialize Laser Cue End ********** ///


    }

    // Update is called once per frame
    void Update()
    {
        //if(ActivateFOVCue)
        //{
        //    FOVCue.SetActive(true);
        //}
        //else
        //{
        //    FOVCue.SetActive(false);
        //}

        //if(ActivateLaserCue)
        //{
        //    LaserCue.SetActive(true);
        //}
        //else
        //{
        //    LaserCue.SetActive(false);
        //}

        //if (ActivateHighlightCue)
        //{
        //    HighlightCue.SetActive(true);
        //}
        //else
        //{
        //    HighlightCue.SetActive(false);
        //}

        //if (ActivateTextCue)
        //{
        //    TextCue.SetActive(true);
        //}
        //else
        //{
        //    TextCue.SetActive(false);
        //}
    }

    /// <summary>
    /// FOVCue
    /// </summary>
    /// <param name="level"></param>
    /// <param name="threatTransform"></param>
    /// <param name="Red_FOV"></param>
    /// <param name="Red_ViewDis"></param>
    /// <param name="Yellow_FOV"></param>
    /// <param name="Yellow_ViewDis"></param>
    /// <param name="Green_FOV"></param>
    /// <param name="Green_ViewDis"></param>
    public void InitializeFOVCue(Level level, Transform threatTransform, float Red_FOV, float Red_ViewDis, float Yellow_FOV, float Yellow_ViewDis, float Green_FOV, float Green_ViewDis)
    {
        /// ********** Initialize FOV Cue ********** ///
        var FOVCue_Red = FOVCue.transform.GetChild(0).GetComponent<FieldOfView>();
        var FOVCue_Yellow = FOVCue.transform.GetChild(1).GetComponent<FieldOfView>();
        var FOVCue_Green = FOVCue.transform.GetChild(2).GetComponent<FieldOfView>();

        // Map to the ground & add a small offset on y axis
        FOVCue_Red.SetOrigin(new Vector3(threatTransform.position.x, 0.20f, threatTransform.position.z));
        FOVCue_Yellow.SetOrigin(new Vector3(threatTransform.position.x, 0.18f, threatTransform.position.z));
        FOVCue_Green.SetOrigin(new Vector3(threatTransform.position.x, 0.16f, threatTransform.position.z));

        Debug.Log("threatTransform.localEulerAngles " + threatTransform.localEulerAngles);
        Debug.Log("threatTransform.EulerAngles " + threatTransform.rotation);
        
        Debug.Log("FOVCue_Red.gameObject.transform.localEulerAngles " + FOVCue_Red.gameObject.transform.localEulerAngles);
        Debug.Log("FOVCue_Red.gameObject.transform.EulerAngles " + FOVCue_Red.gameObject.transform.rotation);

          switch (level)
        {
            case Level.Three:
                FOVCue_Red.SetFOV(Red_FOV);
                FOVCue_Red.SetViewDistance(Red_ViewDis);
                FOVCue_Red.SetDirection(threatTransform.eulerAngles);
                FOVCue_Red.GenerateFOVCue();

                FOVCue_Yellow.SetFOV(Yellow_FOV);
                FOVCue_Yellow.SetViewDistance(Yellow_ViewDis);
                FOVCue_Yellow.SetDirection(threatTransform.eulerAngles);
                FOVCue_Yellow.GenerateFOVCue();

                FOVCue_Green.SetFOV(Green_FOV);
                FOVCue_Green.SetViewDistance(Green_ViewDis);
                FOVCue_Green.SetDirection(threatTransform.eulerAngles);
                FOVCue_Green.GenerateFOVCue();
                break;

            case Level.Two:
                FOVCue_Red.SetFOV(Red_FOV);
                FOVCue_Red.SetViewDistance(Red_ViewDis);
                FOVCue_Red.SetDirection(threatTransform.eulerAngles);
                FOVCue_Red.GenerateFOVCue();

                FOVCue_Yellow.SetFOV(Yellow_FOV);
                FOVCue_Yellow.SetViewDistance(Yellow_ViewDis);
                FOVCue_Yellow.SetDirection(threatTransform.eulerAngles);
                FOVCue_Yellow.GenerateFOVCue();

                FOVCue_Green.SetFOV(0f);
                FOVCue_Green.SetViewDistance(0f);
                break;

            case Level.One:
                FOVCue_Red.SetFOV(Red_FOV);
                FOVCue_Red.SetViewDistance(Red_ViewDis);
                FOVCue_Red.SetDirection(threatTransform.eulerAngles);
                FOVCue_Red.GenerateFOVCue();

                FOVCue_Yellow.SetFOV(0f);
                FOVCue_Yellow.SetViewDistance(0f);

                FOVCue_Green.SetFOV(0f);
                FOVCue_Green.SetViewDistance(0f);
                break;

            default:
                break;

        }

        /// ********** Initialize FOV Cue End ********** ///
        Debug.Log("FOVCue_Red.gameObject.transform.localEulerAngles " + FOVCue_Red.gameObject.transform.localEulerAngles);
        Debug.Log("FOVCue_Red.gameObject.transform.EulerAngles " + FOVCue_Red.gameObject.transform.rotation);

        FOVCue.SetActive(true);
    }

    public void InactivateFOVCue()
    {
        FOVCue.SetActive(false);
    }

    /// <summary>
    /// LaserCue
    /// </summary>
    /// <param name="threatTransform"></param>
    /// <param name="Red_FOV"></param>
    /// <param name="Red_ViewDis"></param>
    public void InitializeLaserCue(Transform threatTransform, float Red_FOV, float Red_ViewDis)
    {
        /// ********** Initialize Laser Cue ********** ///
        var laser = LaserCue.GetComponent<Laser>();
        laser.SetFOV(Red_FOV);
        laser.SetViewDistance(Red_ViewDis);
        laser.GenerateLaserCue(threatTransform);
        /// ********** Initialize Laser Cue End ********** ///

        LaserCue.SetActive(true);
    }

    public void InactivateLaserCue()
    {
        LaserCue.SetActive(false);
    }

    /// <summary>
    /// HighlightCue
    /// </summary>
    /// <param name="threatTransform"></param>
    public void InitializeHighlightCue(Transform threatTransform)
    {
        var highlight = HighlightCue.GetComponent<ChangeThreatColor>();
        highlight.GenerateHighlightCue(threatTransform);
        HighlightCue.SetActive(true);
    }

    public void InactivateHighlightCue()
    {
        HighlightCue.SetActive(false);
    }

    /// <summary>
    /// TextCue
    /// </summary>
    /// <param name="threatTransform"></param>
    public void InitializeTextCue(Transform threatTransform)
    {
        var text = TextCue.GetComponent<ChangeTextColor>();
        text.SetThreatTransform(threatTransform);
        text.SetDistanceOn();
        TextCue.SetActive(true);
    }

    public void InactivateTextCue()
    {
        LaserCue.SetActive(false);
    }
}
