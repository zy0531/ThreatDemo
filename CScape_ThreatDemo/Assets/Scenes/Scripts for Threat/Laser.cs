using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float fov = 90f;
    private Vector3 origin = Vector3.zero;
    private float viewDistance = 50f;

    public float speed = 0.1f;

    LineRenderer lineRenderer;
    float RadialDistance;
    Vector3 VerticalAngle;
    Vector3 StartPos;
    Vector3 EndPos;
    Vector3 InitialVector;

    // Start is called before the first frame update
    void Start()
    {
        //lineRenderer = gameObject.GetComponent<LineRenderer>();
        ////lineRenderer.startWidth = 1f;
        //lineRenderer.useWorldSpace = true;

        //// calculate StartPos and EndPos
        //StartPos = transform.position;
        //VerticalAngle = new Vector3(viewDistance, -transform.position.y, 0).normalized;
        //RadialDistance = Mathf.Sqrt(viewDistance * viewDistance + transform.position.y * transform.position.y);
        //EndPos = transform.position + VerticalAngle * RadialDistance;
        ////record initial vector
        //InitialVector = EndPos - StartPos;

        //lineRenderer.SetPosition(0, StartPos);
        //lineRenderer.SetPosition(1, EndPos);

}

    // Update is called once per frame
    void FixedUpdate()
    {   
        //rotate a point around a pivot
        //https://answers.unity.com/questions/532297/rotate-a-vector-around-a-certain-point.html
        VerticalAngle = EndPos - StartPos;
        if (Vector3.Angle(VerticalAngle, InitialVector) > fov/2.0f)
        {
            speed = -speed;
        }
        VerticalAngle = Quaternion.Euler(0, speed, 0) * VerticalAngle;
        EndPos = VerticalAngle + StartPos;
        lineRenderer.SetPosition(1, EndPos);
    }


    public void SetFOV(float fov)
    {
        this.fov = fov;
    }

    public void SetViewDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }

    public void GenerateLaserCue(Transform threatTransform)
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        //lineRenderer.startWidth = 1f;
        lineRenderer.useWorldSpace = true;

        // calculate StartPos and EndPos
        StartPos = threatTransform.position;
        
        VerticalAngle = new Vector3(viewDistance, -threatTransform.position.y, 0).normalized;
        VerticalAngle = threatTransform.rotation * VerticalAngle;
        RadialDistance = Mathf.Sqrt(viewDistance * viewDistance + threatTransform.position.y * threatTransform.position.y);
        EndPos = threatTransform.position + VerticalAngle * RadialDistance;
        
        //record initial vector
        InitialVector = EndPos - StartPos;

        lineRenderer.SetPosition(0, StartPos);
        lineRenderer.SetPosition(1, EndPos);
    }

}
