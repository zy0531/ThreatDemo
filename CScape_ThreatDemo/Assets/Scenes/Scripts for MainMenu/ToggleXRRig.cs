using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleXRRig : MonoBehaviour
{
    [SerializeField] GameObject XRRig;
    [SerializeField] GameObject XROrigin;
    // Start is called before the first frame update
    void Start()
    {
        XRRig.SetActive(false);
        XRRig.SetActive(true);
        XROrigin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
