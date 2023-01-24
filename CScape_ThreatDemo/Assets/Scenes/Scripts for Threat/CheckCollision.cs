using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] Transform MainCamera;
    CapsuleCollider XRRigCollider;
    Vector3 offset;

    void Start()
    {
        XRRigCollider = GetComponent<CapsuleCollider>();
        offset = MainCamera.position - this.transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("OnCollisionEnter" + collision.gameObject.name);
        if (collision.gameObject.tag == "Red")
        {
            ColorGlobal.InRedArea = true;
            Debug.Log("Red Enter");
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else if (collision.gameObject.tag == "Yellow")
        {
            ColorGlobal.InYellowArea = true;
            Debug.Log("Yellow Enter");
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("OnCollisionExit" + collision.gameObject.name);
        if (collision.gameObject.tag == "Red")
        {
            ColorGlobal.InRedArea = false;
            Debug.Log("Red Exit");
        }
        else if (collision.gameObject.tag == "Yellow")
        {
            ColorGlobal.InYellowArea = false;
            Debug.Log("Yellow Exit");
        }
    }


    void Update()
    {
        // There is an offset between XRRig and MainCamera -- make the position of the XRRig Collider align with the MainCamera
        var Newoffset = MainCamera.position - this.transform.position;
        if(Newoffset != offset) // To allow for floating point inaccuracies, the two vectors are considered equal if the magnitude of their difference is less than 1e-5.
        {
            offset = Newoffset;
            //Debug.Log(offset);
            XRRigCollider.center = new Vector3(offset.x, offset.y, offset.z);
        }


        // Count time in different zones
        if (ColorGlobal.InRedArea)
            ColorGlobal.UsedTimeInRed += Time.deltaTime;
        else if (ColorGlobal.InYellowArea)
            ColorGlobal.UsedTimeInYellow += Time.deltaTime;
    }


}
