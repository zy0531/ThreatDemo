using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderPropertyController : MonoBehaviour
{
    [SerializeField] Material BackObjectThreatAreaRedMaterial;
    [SerializeField] Material BackObjectThreatAreaYellowMaterial;
    [SerializeField] Material BackObjectThreatAreaGreenMaterial;
    [SerializeField] Material BackObjectGroundCircleContourMaterial;

    // Start is called before the first frame update
    void Start()
    {
        BackObjectThreatAreaRedMaterial.SetInt("_RefNumber", 1);
        BackObjectThreatAreaYellowMaterial.SetInt("_RefNumber", 1);
        BackObjectThreatAreaGreenMaterial.SetInt("_RefNumber", 1);
        BackObjectGroundCircleContourMaterial.SetInt("_RefNumber", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change the Reference number of the shader to render through the corresponding portal
    public void ChangeShaderRefNum(int RefNumber)
    {
        BackObjectThreatAreaRedMaterial.SetInt("_RefNumber", RefNumber);
        BackObjectThreatAreaYellowMaterial.SetInt("_RefNumber", RefNumber);
        BackObjectThreatAreaGreenMaterial.SetInt("_RefNumber", RefNumber);
        BackObjectGroundCircleContourMaterial.SetInt("_RefNumber", RefNumber);
    }
}
