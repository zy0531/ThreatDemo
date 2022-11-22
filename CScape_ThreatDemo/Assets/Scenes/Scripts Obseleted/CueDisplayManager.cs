using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueDisplayManager : MonoBehaviour
{
    //public CueType CueType;
    //public InfoType InfoType;
    //[SerializeField] GameObject WorldARCues;
    //[SerializeField] GameObject WorldARCues_Landmark;
    //[SerializeField] GameObject ScreenARCues;
    //[SerializeField] GameObject ScreenARCues_Landmark;
    //[SerializeField] GameObject BodyARCue; //Body fixed AR cue: used together with ScreenARCues 
    //[SerializeField] GameObject DecisionPoints;


    //void Start()
    //{
    //    if (CueType == CueType.ScreenFixed)
    //    {
    //        //ScreenArrowCue = ScreenARCues.transform.GetChild(0).gameObject;
    //        BodyARCue.SetActive(true);
    //        if (InfoType == InfoType.WithLandmark)
    //        {
    //            ScreenARCues_Landmark.SetActive(true);
    //        }

    //    }
    //    else if (CueType == CueType.WorldFixed)
    //    {
    //        //WorldARCues.SetActive(true);
    //        if (InfoType == InfoType.WithLandmark)
    //        {
    //            WorldARCues_Landmark.SetActive(true);
    //        }
    //    }
    //}

    //void Update()
    //{
    //    if (CueType == CueType.ScreenFixed)
    //    {
    //        float dist = Vector3.Distance(Camera.main.transform.position, DecisionPoints.transform.GetChild(TriggerNaviInstructions.index).gameObject.transform.position);
    //        GameObject CurrentScreenArrowCue = ScreenARCues.transform.GetChild(TriggerNaviInstructions.index).gameObject;
    //        UpdateDistanceText(dist, CurrentScreenArrowCue);
    //    }    
    //}

    //public void ActiveARCue()
    //{
    //    if (CueType == CueType.ScreenFixed)
    //    {
    //        ScreenARCues.transform.GetChild(TriggerNaviInstructions.index).gameObject.SetActive(true);
    //    }
    //    else if (CueType == CueType.WorldFixed)
    //    {
    //        WorldARCues.transform.GetChild(TriggerNaviInstructions.index).gameObject.SetActive(true);
    //    }  
    //}

    //public void InActiveARCue()
    //{
    //    if (CueType == CueType.ScreenFixed)
    //    {
    //        ScreenARCues.transform.GetChild(TriggerNaviInstructions.index).gameObject.SetActive(false);
    //    }
    //    else if (CueType == CueType.WorldFixed)
    //    {
    //        WorldARCues.transform.GetChild(TriggerNaviInstructions.index).gameObject.SetActive(false);
    //    }
    //}

    //public void UpdateDistanceText(float dist, GameObject CurrentScreenArrowCue)
    //{
    //    if (dist > 50f)
    //        CurrentScreenArrowCue.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "100m";
    //    else if (dist > 20f)
    //        CurrentScreenArrowCue.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "50m";
    //    else if (dist > 10f)
    //        CurrentScreenArrowCue.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "20m";
    //    else
    //        CurrentScreenArrowCue.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "10m";
    //}
}
