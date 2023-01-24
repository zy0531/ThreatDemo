using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to the end position
/// </summary>
public class TriggerDestination : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable New route (for start position trigger new route name - "ColorGlobal.CurrentRoute")
            Transform route = this.transform.parent.transform;
            int index = route.GetSiblingIndex();
            if (index + 1 < route.parent.childCount)
            {
                route.parent.GetChild(index + 1).gameObject.SetActive(true);
            }   
            else
            {
                ColorGlobal.CurrentRoute = "End of Routes";
                Debug.Log("End of Routes (Destination Trigger) !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
                
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the Current Segment of Route
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
