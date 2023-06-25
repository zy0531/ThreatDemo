using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTintColor : MonoBehaviour
{
    [SerializeField] Image tintImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ColorGlobal.InRedArea)
        {
            //Debug.Log("Text in Red");
            tintImage.color = Color.red;
            Color tintColor = tintImage.color;
            tintColor.a = 0.1f;
            tintImage.color = tintColor;
        }
        else if (ColorGlobal.InYellowArea)
        {
            //Debug.Log("Text in Yellow");
            tintImage.color = Color.yellow;
            Color tintColor = tintImage.color;
            tintColor.a = 0.1f;
            tintImage.color = tintColor;
        }
        else
        {
            //Debug.Log(ThreatDistanceText);
            //Debug.Log("Text in Green");
            
            //tintImage.color = Color.white;
            // change alpha;
            Color tintColor = tintImage.color;
            tintColor.a = 0;
            tintImage.color = tintColor;
        }
    }
}
