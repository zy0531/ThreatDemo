using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCondition : MonoBehaviour
{
    //[SerializeField] GameObject WorldARCues_Direction_Route1;
    [SerializeField] GameObject WorldARCues_Direction_Route2;

    //[SerializeField] GameObject ScreenARCues_Direction_Route1;
    [SerializeField] GameObject ScreenARCues_Direction_Route2;

    //[SerializeField] GameObject WorldARCues_Landmark_Route1;
    [SerializeField] GameObject WorldARCues_Landmark_Route2;

    //[SerializeField] GameObject ScreenARCues_Landmark_Route1;
    [SerializeField] GameObject ScreenARCues_Landmark_Route2;

    //[SerializeField] GameObject WorldARCues_Straight_Route1;
    [SerializeField] GameObject WorldARCues_Straight_Route2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeConditionRoute2()
    {
        WorldARCues_Direction_Route2.SetActive(false);
        ScreenARCues_Direction_Route2.SetActive(false);
        WorldARCues_Landmark_Route2.SetActive(false);
        ScreenARCues_Landmark_Route2.SetActive(false);

        WorldARCues_Straight_Route2.SetActive(false);

        //Read in TransferValue.cueType_Message sent from the Dropdown UI
        if (TransferValue.cueType_Message == "ScreenFixed")
        {
            ScreenARCues_Direction_Route2.SetActive(true);
            //Read in TransferValue.infoType_Message sent from the Dropdown UI
            if (TransferValue.infoType_Message == "WithLandmark")
            {
                ScreenARCues_Landmark_Route2.SetActive(true);
            }
        }

        else if (TransferValue.cueType_Message == "WorldFixed")
        {
            WorldARCues_Direction_Route2.SetActive(true);
            WorldARCues_Straight_Route2.SetActive(true);
            //Read in TransferValue.infoType_Message sent from the Dropdown UI
            if (TransferValue.infoType_Message == "WithLandmark")
            {
                WorldARCues_Landmark_Route2.SetActive(true);
            }
        }
    }
}
