using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrialText : MonoBehaviour
{
    [SerializeField] TMP_Text TrialTxt;
    bool TrialOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TrialOn)
            TrialTxt.text = "Trial: " + ColorGlobal.trial + "/20";
    }

    public void SetTrialOn()
    {
        TrialOn = true;
    }
}
