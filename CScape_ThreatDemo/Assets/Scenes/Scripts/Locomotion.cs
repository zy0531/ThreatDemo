using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Locomotion : MonoBehaviour
{
    public Transform xrRig;
    public Transform head;
    public Transform bodyTracker;
    [Header("Use controller.primaryButton to move")]
    public float moveSpeed = 1.80f;

    InputDevice device;
    bool ButtonState;
    Vector2 primary2DAxisState;

    // Start is called before the first frame update
    void Start()
    {
        //Find Right Controller
        var RightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, RightHandDevices);

        if (RightHandDevices.Count == 1)
        {
            device = RightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }
        else if (RightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }
    }

        // Update is called once per frame
    void Update()
    {
        //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out ButtonState) && ButtonState) // using primary button
        //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out ButtonState) && ButtonState) // using joystick
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out ButtonState) && ButtonState) // using joystick
        {
            //Head-based steering
            //xrRig.transform.Translate(VectorYToZero(head.forward) * moveSpeed * Time.deltaTime, Space.World);

            //Body-based steering (Body rotation is tracked by a Vive Tracker)
            //xrRig.transform.Translate(ProjectToXZPlane(bodyTracker.up) * moveSpeed * Time.deltaTime, Space.World);

            //Joystick-based steering (rotation is determined by the controller)
            //xrRig.transform.Translate(ProjectToXZPlane(this.transform.forward) * moveSpeed * Time.deltaTime, Space.World);
            xrRig.transform.Translate(ProjectToXZPlane(this.transform.forward) * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    Vector3 ProjectToXZPlane(Vector3 v)
    {
        return new Vector3(v.x, 0.0f, v.z).normalized;
        // for the specific projection to x-z plane, simply setting y to 0 works.
    }
}

