using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColor : MonoBehaviour
{
    /// <summary>
    /// Generate trigger zone
    /// (same code as FieldOfView.cs, but not rendering the zone)
    /// </summary>
    private float fov;
    private Vector3 origin = Vector3.zero;
    private float viewDistance;
    private float startingAngle;
    MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetFOV(float fov)
    {
        this.fov = fov;
    }

    public void SetViewDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }

    public Vector3 GetOrigin()
    {
        return this.origin;
    }

    public float GetFOV()
    {
        return this.fov;
    }

    public float GetViewDistance()
    {
        return this.viewDistance;
    }

    public void SetDirection(Vector3 direction)
    {
        // In unity, clockwise direction is positive; in generating mesh, anti-clockwise is positive.
        float n = 360 - direction.y;
        startingAngle = n + this.fov / 2f;

        //Debug.Log("direction" + direction);
        //Debug.Log("fov/2:" + fov / 2f);
        //Debug.Log("startingAngle" + startingAngle);
        //Debug.Log("**********************************");
    }

    public void GenerateTriggerZone()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        int rayCount = 50;
        //float angle = this.fov / 2f;
        float angle = startingAngle;
        float angleIncrease = this.fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];


        vertices[0] = this.origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex = this.origin + UtilsClass.GetVectorFromAngle(angle) * this.viewDistance;
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }


            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


        // Add mesh collider
        if (this.GetComponent<MeshFilter>() != null)
        {
            if (this.viewDistance > 0f)
                meshCollider = this.gameObject.AddComponent<MeshCollider>();
            //meshCollider.isTrigger = true;
        }
    }
}
