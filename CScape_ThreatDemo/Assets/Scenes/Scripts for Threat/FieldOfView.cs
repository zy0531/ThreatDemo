using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference: https://www.youtube.com/watch?v=CSeUMTaNFYk
public class FieldOfView : MonoBehaviour
{
    private float fov;
    private Vector3 origin = Vector3.zero;
    float viewDistance;
    float startingAngle;
    MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        //Mesh mesh = new Mesh();
        //GetComponent<MeshFilter>().mesh = mesh;

        //int rayCount = 50;
        //float angle = fov/2f;
        //float angleIncrease = fov / rayCount;

        //Vector3[] vertices = new Vector3[rayCount+1+1];
        //Vector2[] uv = new Vector2[vertices.Length];
        //int[] triangles = new int[rayCount*3];


        //vertices[0] = origin;
        //int vertexIndex = 1;
        //int triangleIndex = 0;
        //for (int i = 0; i<=rayCount; i++)
        //{
        //    Vector3 vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
        //    vertices[vertexIndex] = vertex;

        //    if (i > 0)
        //    {
        //        triangles[triangleIndex + 0] = 0;
        //        triangles[triangleIndex + 1] = vertexIndex - 1;
        //        triangles[triangleIndex + 2] = vertexIndex;

        //        triangleIndex += 3;
        //    }


        //    vertexIndex++;
        //    angle -= angleIncrease;
        //}

        //mesh.vertices = vertices;
        //mesh.uv = uv;
        //mesh.triangles = triangles;



        //// Add mesh collider
        //if (this.GetComponent<MeshFilter>() != null)
        //{
        //    if (viewDistance > 0f)
        //        meshCollider = this.gameObject.AddComponent<MeshCollider>();
        //    //meshCollider.isTrigger = true;
        //}
    }

    // Update is called once per frame
    void Update()
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

    public void SetDirection(Vector3 direction)
    {
        // In unity, clockwise direction is positive; in generating mesh, anti-clockwise is positive.
        float n = 360 - direction.y;
        startingAngle = n + this.fov / 2f;
    }

    public void GenerateFOVCue()
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
