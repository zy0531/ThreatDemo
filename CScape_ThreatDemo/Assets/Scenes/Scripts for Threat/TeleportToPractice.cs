using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPractice : MonoBehaviour
{
    [SerializeField] GameObject xrRig;
    [SerializeField] Transform PracticePosition;
    [SerializeField] GameObject PracticeEndPos1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ColorGlobal.IsPractice && Input.GetKeyDown(KeyCode.P))
        {
            xrRig.transform.position = PracticePosition.position;
            PracticeEndPos1.SetActive(true);
            ColorGlobal.IsPractice = true;
            ColorGlobal.IsMovement = true;
        }
    }
}
