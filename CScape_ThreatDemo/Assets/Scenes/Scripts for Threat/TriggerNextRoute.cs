using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to the start position
/// </summary>
public class TriggerNextRoute : MonoBehaviour
{
    [SerializeField] AudioSource StartNavigationAudio;
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
            //Debug.Log("CurrentRoute Trigger Name " + this.transform.parent.gameObject.name);
            ColorGlobal.CurrentRoute = this.transform.parent.gameObject.name;
            //StartNavigationAudio.PlayDelayed(2);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("CurrentRoute Trigger Name " + this.transform.parent.gameObject.name);
            ColorGlobal.CurrentRoute = this.transform.parent.gameObject.name;
        }
    }
}
