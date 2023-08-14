using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPrompt : MonoBehaviour
{
    [SerializeField] GameObject BreakCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ColorGlobal.IsMovement && ColorGlobal.trial == 13)
        {
            BreakCanvas.SetActive(true);
        }
        else
        {
            BreakCanvas.SetActive(false);
        }
    }
}
