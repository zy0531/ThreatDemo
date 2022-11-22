using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleXRRig_Exploration : MonoBehaviour
{
    [SerializeField] GameObject XRRig;
    [SerializeField] GameObject XROrigin;
    // Start is called before the first frame update
    void Start()
    {
        XROrigin.SetActive(false);
        XROrigin.SetActive(true);
        XRRig.SetActive(false);
        XRRig.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
