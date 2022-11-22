using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueManager : MonoBehaviour
{
    [SerializeField] int level = 3;
    
    [SerializeField] Transform threatTransform;

    [SerializeField] float viewDistance_L1_Red;
    [SerializeField] float fov_L1_Red;
    [SerializeField] float viewDistance_L2_Yellow;
    [SerializeField] float fov_L2_Yellow;
    [SerializeField] float viewDistance_L3_Green;
    [SerializeField] float fov_L3_Green;

    /// <summary>
    /// Trigger
    /// </summary>
    [SerializeField] GameObject TriggerRed;
    [SerializeField] GameObject TriggerYellow;
    [SerializeField] GameObject TriggerGreen;

    /// <summary>
    /// FOV Cue
    /// </summary>
    [SerializeField] public bool ActivateFOVCue;
    [SerializeField] GameObject FOVCue;

    /// <summary>
    /// Laser Cue
    /// </summary>
    [SerializeField] public bool ActivateLaserCue;
    [SerializeField] GameObject LaserCue;

    /// <summary>
    /// Building Highlight Cue
    /// </summary>
    [SerializeField] public bool ActivateBuildingHighlightCue;
    [SerializeField] GameObject BuildingHighlightCue;

    /// <summary>
    /// Text Cue
    /// </summary>
    [SerializeField] public bool ActivateTextCue;
    [SerializeField] GameObject TextCue;


    // Start is called before the first frame update
    void Start()
    {
        // Set Trigger
        TriggerRed.GetComponent<SphereCollider>().radius = viewDistance_L1_Red;
        TriggerRed.GetComponent<SphereCollider>().center = new Vector3(threatTransform.position.x, 0, threatTransform.position.z);
        TriggerYellow.GetComponent<SphereCollider>().radius = viewDistance_L2_Yellow;
        TriggerYellow.GetComponent<SphereCollider>().center = new Vector3(threatTransform.position.x, 0, threatTransform.position.z);
        TriggerGreen.GetComponent<SphereCollider>().radius = viewDistance_L3_Green;
        TriggerGreen.GetComponent<SphereCollider>().center = new Vector3(threatTransform.position.x, 0, threatTransform.position.z);

        /// ********** Initialize FOV Cue ********** ///
            var FOVCue_Red = FOVCue.transform.GetChild(0).GetComponent<FieldOfView>();
            var FOVCue_Yellow = FOVCue.transform.GetChild(1).GetComponent<FieldOfView>();
            var FOVCue_Green = FOVCue.transform.GetChild(2).GetComponent<FieldOfView>();
            Debug.Log(FOVCue_Yellow);

            // Map to the ground & add a small offset on y axis
            FOVCue_Red.SetOrigin(new Vector3(threatTransform.position.x, 0.20f, threatTransform.position.z));
            FOVCue_Yellow.SetOrigin(new Vector3(threatTransform.position.x, 0.18f, threatTransform.position.z));
            FOVCue_Green.SetOrigin(new Vector3(threatTransform.position.x, 0.16f, threatTransform.position.z));

            switch (level)
            {
                case 3:
                    FOVCue_Red.SetFOV(fov_L1_Red);
                    FOVCue_Red.SetViewDistance(viewDistance_L1_Red);
                    FOVCue_Yellow.SetFOV(fov_L2_Yellow);
                    FOVCue_Yellow.SetViewDistance(viewDistance_L2_Yellow);
                    FOVCue_Green.SetFOV(fov_L3_Green);
                    FOVCue_Green.SetViewDistance(viewDistance_L3_Green);
                    break;

                case 2:
                    FOVCue_Yellow.SetFOV(fov_L2_Yellow);
                    FOVCue_Yellow.SetViewDistance(viewDistance_L2_Yellow);
                    FOVCue_Green.SetFOV(fov_L3_Green);
                    FOVCue_Green.SetViewDistance(viewDistance_L3_Green);
                    break;

                case 1:
                    FOVCue_Green.SetFOV(fov_L3_Green);
                    FOVCue_Green.SetViewDistance(viewDistance_L3_Green);
                    break;
                
                default:
                    break;

            }
        /// ********** Initialize FOV Cue End ********** ///




        /// ********** Initialize Laser Cue ********** ///
        var laser = LaserCue.GetComponent<Laser>();
        laser.SetFOV(fov_L1_Red);
        laser.SetViewDistance(viewDistance_L1_Red);
        /// ********** Initialize Laser Cue End ********** ///


    }

    // Update is called once per frame
    void Update()
    {
        if(ActivateFOVCue)
        {
            FOVCue.SetActive(true);
        }
        else
        {
            FOVCue.SetActive(false);
        }

        if(ActivateLaserCue)
        {
            LaserCue.SetActive(true);
        }
        else
        {
            LaserCue.SetActive(false);
        }

        if (ActivateBuildingHighlightCue)
        {
            BuildingHighlightCue.SetActive(true);
        }
        else
        {
            BuildingHighlightCue.SetActive(false);
        }

        if (ActivateTextCue)
        {
            TextCue.SetActive(true);
        }
        else
        {
            TextCue.SetActive(false);
        }
    }
}
