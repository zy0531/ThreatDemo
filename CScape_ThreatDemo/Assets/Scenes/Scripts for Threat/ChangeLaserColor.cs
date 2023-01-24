using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLaserColor : MonoBehaviour
{
    [SerializeField] float Cue_alpha = 0f;
    LineRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<LineRenderer>();
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
            Color color = Color.white;
            color.a = Cue_alpha;
            meshRenderer.material.SetColor("_Color", color);
        }
    }
}
