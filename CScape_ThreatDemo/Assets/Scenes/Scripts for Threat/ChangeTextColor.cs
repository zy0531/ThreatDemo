using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextColor : MonoBehaviour
{
    //[SerializeField] GameObject ThreatBuilding;
    Transform ThreatTransform;
    [SerializeField] TMP_Text ThreatDistanceText;
    public bool distanceOn = false;
    private float distance = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(distanceOn)
        {
            distance = Vector3.Distance(Camera.main.transform.position, ThreatTransform.position);
            if (ColorGlobal.InRedArea)
            {
                //Debug.Log("Text in Red");
                ThreatDistanceText.color = Color.red;
                ThreatDistanceText.text = "Distance to Threat " + distance.ToString("F0") + " Meters";
            }
            else if (ColorGlobal.InYellowArea)
            {
                //Debug.Log("Text in Yellow");
                ThreatDistanceText.color = Color.yellow;
                ThreatDistanceText.text = "Distance to Threat " + distance.ToString("F0") + " Meters";
            }
            else
            {
                //Debug.Log(ThreatDistanceText);
                //Debug.Log("Text in Green");
                ThreatDistanceText.color = Color.white;
                ThreatDistanceText.text = "Distance to Threat " + distance.ToString("F0") + " Meters";
            }
        }
        
    }


    public void SetDistanceOn()
    {
        Debug.Log("SetdistanceOn!");
        distanceOn = true;
        distance = 0f;
    }

    public void SetDistanceOff()
    {
        Debug.Log("SetdistanceOff!");
        distance = 0f;
        distanceOn = false;
        ThreatDistanceText.text = "";
    }

    public void SetThreatTransform(Transform threatTransform)
    {
        ThreatTransform = threatTransform;
    }


}
