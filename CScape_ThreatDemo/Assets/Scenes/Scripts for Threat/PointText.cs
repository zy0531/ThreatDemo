using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointText : MonoBehaviour
{
    [SerializeField] TMP_Text PointTxt;

    public bool PointOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PointOn)
        {
            // Point system
            if (ColorGlobal.UsedTime < 50f)
                ColorGlobal.Point = ColorGlobal.Point_TrialEnd
                    // points based on total spent time
                    + ColorGlobal.UsedTime * 2f
                    // points based on time in each zone
                    + (ColorGlobal.UsedTime - ColorGlobal.UsedTimeInRed - ColorGlobal.UsedTimeInYellow) * 1f
                    - ColorGlobal.UsedTimeInYellow * 1f
                    - ColorGlobal.UsedTimeInRed * 3f;
            else if (ColorGlobal.UsedTime < 60f)
                ColorGlobal.Point = ColorGlobal.Point_TrialEnd
                    // points based on total spent time
                    + 50f * 2f
                    + (ColorGlobal.UsedTime - 50f) * 2f
                    // points based on time in each zone
                    + (ColorGlobal.UsedTime - ColorGlobal.UsedTimeInRed - ColorGlobal.UsedTimeInYellow) * 1f
                    - ColorGlobal.UsedTimeInYellow * 1f
                    - ColorGlobal.UsedTimeInRed * 3f;
            else if (ColorGlobal.UsedTime < 70f)
                ColorGlobal.Point = ColorGlobal.Point_TrialEnd
                    // points based on total spent time
                    + 50f * 2f
                    + (60f - 50f) * 2f
                    - (ColorGlobal.UsedTime - 60f) * 1f
                    // points based on time in each zone
                    + (ColorGlobal.UsedTime - ColorGlobal.UsedTimeInRed - ColorGlobal.UsedTimeInYellow) * 1f
                    - ColorGlobal.UsedTimeInYellow * 1f
                    - ColorGlobal.UsedTimeInRed * 3f;
            else // spend more than 70s
                ColorGlobal.Point = ColorGlobal.Point_TrialEnd
                   // points based on total spent time
                   + 50f * 2f
                   + (60f - 50f) * 2f
                   - (70f - 60f) * 1f
                   - (ColorGlobal.UsedTime - 70f) * 2f
                   // points based on time in each zone
                   + (ColorGlobal.UsedTime - ColorGlobal.UsedTimeInRed - ColorGlobal.UsedTimeInYellow) * 1f
                   - ColorGlobal.UsedTimeInYellow * 1f
                   - ColorGlobal.UsedTimeInRed * 3f;

            UpdatePointTxt(ColorGlobal.Point);
        }
    }

    public void SetPointOn()
    {
        Debug.Log("SetPointOn!");
        PointOn = true;
        ColorGlobal.Point = 0f;
    }

    public void SetPointOff()
    {
        Debug.Log("SetPointOff!");
        ColorGlobal.Point = 0f;
        PointOn = false;
        PointTxt.text = "";
    }

    private void UpdatePointTxt(float Point)
    {
        PointTxt.text = "Points: " + Point.ToString("f0");
    }
}
