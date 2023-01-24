using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerThreat : MonoBehaviour
{
    [SerializeField] TMP_Text TimerTxt;

    public bool TimerOn = false;
    // public float ColorGlobal.UsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            ColorGlobal.UsedTime += Time.deltaTime;
            UpdateTimerTxt(ColorGlobal.UsedTime);
        }
    }

    public void SetTimerOn()
    {
        Debug.Log("SetTimerOn!");
        TimerOn = true;
        ColorGlobal.UsedTime = 0f;
    }

    public void SetTimerOff()
    {
        Debug.Log("SetTimerOff!");
        ColorGlobal.UsedTime = 0f;
        TimerOn = false;
        TimerTxt.text = "";
    }

    private void UpdateTimerTxt(float UsedTime)
    {
        UsedTime += 1;
        float minutes = Mathf.FloorToInt(UsedTime / 60);
        float seconds = Mathf.FloorToInt(UsedTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds)
            + "\n UsedTime:" + ColorGlobal.UsedTime
            + "\n UsedTimeInRed:" + ColorGlobal.UsedTimeInRed
            + "\n UsedTimeInYellow:" + ColorGlobal.UsedTimeInYellow;
    }
}
