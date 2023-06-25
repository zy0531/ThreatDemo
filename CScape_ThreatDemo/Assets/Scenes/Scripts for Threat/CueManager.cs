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

    /// <summary>
    /// Screen Tint Cue
    /// </summary>
    [SerializeField] GameObject ScreenTintCue;


    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        
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
        FOVCue_Red.SetOrigin(new Vector3(threatTransform.position.x, 0.12f, threatTransform.position.z));
        FOVCue_Yellow.SetOrigin(new Vector3(threatTransform.position.x, 0.11f, threatTransform.position.z));
        FOVCue_Green.SetOrigin(new Vector3(threatTransform.position.x, 0.10f, threatTransform.position.z));

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
    public void InitializeHighlightCue(Transform threatTransform, GameObject threatBuilding)
    {
        var highlight = HighlightCue.GetComponent<ChangeThreatColor>();
        highlight.GenerateHighlightCue(threatTransform, threatBuilding);
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
        TextCue.SetActive(false);
    }



    /// <summary>
    /// ScreenTintCue
    /// </summary>
    public void InitializeScreenTintCue()
    {
        ScreenTintCue.SetActive(true);
    }

    public void InactivateScreenTintCue()
    {
        ScreenTintCue.SetActive(false);
    }
}
