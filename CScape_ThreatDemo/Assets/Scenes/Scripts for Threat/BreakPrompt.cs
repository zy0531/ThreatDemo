using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPrompt : MonoBehaviour
{
    [SerializeField] GameObject BreakCanvas;
    // Start is called before the first frame update
    void Start()
    {
        BreakCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ColorGlobal.IsMovement && ColorGlobal.trial == 10)
        {
            if (!ColorGlobal.IsBreak)
            {
                BreakCanvas.SetActive(true);
                ColorGlobal.IsBreak = true;
            }
                
        }
        //else
        //{
        //    BreakCanvas.SetActive(false);
        //}


        if (Input.GetKeyUp(KeyCode.B))
        {
            if (ColorGlobal.IsBreak)
            {
                BreakCanvas.SetActive(false);
            }
        }
    }
}
