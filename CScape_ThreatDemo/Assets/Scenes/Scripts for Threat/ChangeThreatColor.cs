using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeThreatColor : MonoBehaviour
{
    [SerializeField] Transform Cue_position;
    [SerializeField] float Cue_alpha = 0f;
    [SerializeField] float Cue_x = 0f;
    [SerializeField] float Cue_y = 0f;
    [SerializeField] float Cue_z = 0f;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //set position
        transform.position = Cue_position.position;
        //set scale
        transform.localScale = new Vector3(Cue_x, Cue_y, Cue_z);

        meshRenderer = GetComponent<MeshRenderer>();
        // get color
        meshRenderer.material.GetColor("_Color");
    }
    // Update is called once per frame
    void Update()
    {
        if (ColorGlobal.InRedArea)
        {
            //Debug.Log("Text in Red");
            // set red
            Color color = Color.red;
            color.a = Cue_alpha;
            meshRenderer.material.SetColor("_Color", color);
        }
        else if (ColorGlobal.InYellowArea)
        {
            //Debug.Log("Text in Yellow");
            // set yellow
            Color color = Color.yellow;
            color.a = Cue_alpha;
            meshRenderer.material.SetColor("_Color", color);
        }
        else
        {
            //Debug.Log("Text in Green");
            // set green
            Color color = Color.green;
            color.a = Cue_alpha;
            meshRenderer.material.SetColor("_Color", color);
        }
    }
}
