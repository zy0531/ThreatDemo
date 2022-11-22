using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (this.gameObject.name == "Red")
            {
                ColorGlobal.InRedArea = true;
            }
            else if (this.gameObject.name == "Yellow")
            {
                ColorGlobal.InYellowArea = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (this.gameObject.name == "Red")
            {
                ColorGlobal.InRedArea = true;
            }
            else if (this.gameObject.name == "Yellow")
            {
                ColorGlobal.InYellowArea = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (this.gameObject.name == "Red")
            {
                ColorGlobal.InRedArea = false;
            }
            else if (this.gameObject.name == "Yellow")
            {
                ColorGlobal.InYellowArea = false;
            }
        }
    }

    //public void SetRadius(float radius)
    //{
    //    this.GetComponent<SphereCollider>().radius = radius;
    //}
}
