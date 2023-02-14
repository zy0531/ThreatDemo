using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeThreatColor : MonoBehaviour
{
    //[SerializeField] Transform Cue_position;
    [SerializeField] float Cue_alpha = 0f;
    [SerializeField] float Cue_x = 0f;
    [SerializeField] float Cue_y = 0f;
    [SerializeField] float Cue_z = 0f;
    [SerializeField] Color _OutlineColor;
    //[SerializeField] GameObject threatBuilding;
    MeshRenderer meshRenderer;
    Color HighlightColor;
    Color OutlineColor;
    float OutlineColorAlpha;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<MeshFilter>().mesh.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        if (ColorGlobal.InRedArea)
        {
            //Debug.Log("in Red Zone");
            // set red
            HighlightColor = Color.red;
            HighlightColor.a = Cue_alpha;
            meshRenderer.materials[0].SetColor("_Color", HighlightColor);

            //inactivate outline
            //OutlineColor.a = 0;
            //meshRenderer.materials[1].SetColor("_OutlineColor", OutlineColor);
        }
        else if (ColorGlobal.InYellowArea)
        {
            //Debug.Log("in Yellow Zone");
            // set yellow
            HighlightColor = Color.yellow;
            HighlightColor.a = Cue_alpha;
            meshRenderer.materials[0].SetColor("_Color", HighlightColor);

            //inactivate outline
            //OutlineColor.a = 0;
            //meshRenderer.materials[1].SetColor("_OutlineColor", OutlineColor);
        }
        // Default Color
        else
        {
            //Debug.Log("in Safe Zone");
            //inactivate highlight
            HighlightColor.a = 0;
            meshRenderer.materials[0].SetColor("_Color", HighlightColor);

            //activate outline
            //OutlineColor.a = OutlineColorAlpha;
            //meshRenderer.materials[1].SetColor("_OutlineColor", OutlineColor);
        }
    }

    public void GenerateHighlightCue(Transform threatTransform, GameObject threatBuilding)
    {
        ////set position
        //this.transform.position = threatTransform.position;
        ////set scale
        //this.transform.localScale = new Vector3(Cue_x, Cue_y, Cue_z);

        //set position
        this.transform.position = threatBuilding.transform.position;
        //set rotation
        this.transform.rotation = threatBuilding.transform.rotation;
        //set scale
        this.transform.localScale = threatBuilding.transform.localScale;

        //get meshfilter
        Mesh threatBuildingMesh;
        threatBuildingMesh = threatBuilding.GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = threatBuildingMesh;
        //GetComponent<MeshFilter>().sharedMesh = threatBuildingMesh;

        //get mesh renderer
        meshRenderer = this.GetComponent<MeshRenderer>();
        List<Material> materials = new List<Material>();
        meshRenderer.GetMaterials(materials);

        // get materials[0] HighlightColor
        HighlightColor = materials[0].color;

        // get materials[1] OutlineColor
        OutlineColor = _OutlineColor;
        OutlineColorAlpha = _OutlineColor.a;
    }
}
