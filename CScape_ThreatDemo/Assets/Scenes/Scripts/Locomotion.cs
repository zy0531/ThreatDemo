using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Locomotion : MonoBehaviour
{
    public Transform xrRig;
    public Rigidbody rigidbody;
    public Transform head;
    public Transform bodyTracker;
    [Header("Use controller.primaryButton to move")]
    public float moveSpeed = 4.0f;

    InputDevice device;
    InputDevice device_left;
    bool ButtonState;
    Vector2 primary2DAxisState;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Rigidbody
        rigidbody = rigidbody.GetComponent<Rigidbody>();

        //Find Right Controller
        var RightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, RightHandDevices);

        //Find Left Controller
        var LeftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, LeftHandDevices);

        if (RightHandDevices.Count == 1)
        {
            device = RightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }
        else if (RightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }

        if (LeftHandDevices.Count == 1)
        {
            device_left = LeftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device_left.name, device_left.role.ToString()));
        }
        else if (LeftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }
    }

    // ******************* using Translate to locomote, but you can go through the walls ******************* //
    //void Update()
    //{
    //    //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out ButtonState) && ButtonState) // using primary button
    //    //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out ButtonState) && ButtonState) // using joystick
    //    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out ButtonState) && ButtonState) // using joystick
    //    {
    //        //Head-based steering
    //        //xrRig.transform.Translate(VectorYToZero(head.forward) * moveSpeed * Time.deltaTime, Space.World);

    //        //Body-based steering (Body rotation is tracked by a Vive Tracker)
    //        //xrRig.transform.Translate(ProjectToXZPlane(bodyTracker.up) * moveSpeed * Time.deltaTime, Space.World);

    //        //Joystick-based steering (rotation is determined by the controller)
    //        //xrRig.transform.Translate(ProjectToXZPlane(this.transform.forward) * moveSpeed * Time.deltaTime, Space.World);

    //        
    //    }
    //}

    // ******************* using Rigidbody to locomote to avoid going through the walls ******************* //
    void FixedUpdate()
    {
        Debug.DrawLine(bodyTracker.position, bodyTracker.position + bodyTracker.forward);
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out ButtonState) && ButtonState) // using joystick
        {
            //Body-based steering (Body rotation is tracked by a Vive Tracker)
            //rigidbody.velocity = ProjectToXZPlane(bodyTracker.up) * moveSpeed;
            rigidbody.velocity = ProjectToXZPlane(bodyTracker.forward) * moveSpeed;
            
            //Joystick-based steering (rotation is determined by the controller)
            //rigidbody.velocity = ProjectToXZPlane(this.transform.forward) * moveSpeed;
        }
    }

    Vector3 ProjectToXZPlane(Vector3 v)
    {
        return new Vector3(v.x, 0.0f, v.z).normalized;
        // for the specific projection to x-z plane, simply setting y to 0 works.
    }
}

