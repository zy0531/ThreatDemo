using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownRoute : MonoBehaviour
{
    //Attach this script to a Dropdown GameObject
    TMP_Dropdown m_Dropdown;
    //This is the string that stores the current selection m_Text of the Dropdown
    string routeType_Message;
    //This Text outputs the current selection to the screen
    public TMP_Text m_Text;
    //This is the index value of the Dropdown
    int m_DropdownValue;

    void Start()
    {
        //Fetch the DropDown component from the GameObject
        m_Dropdown = transform.GetComponent<TMP_Dropdown>();
        //Output the first Dropdown index value
        Debug.Log("Starting Dropdown Value : " + m_Dropdown.value);
    }

    void Update()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;
        //Change the message to say the name of the current Dropdown selection using the value
        routeType_Message = m_Dropdown.options[m_DropdownValue].text;
        TransferValue.routeType_Message = routeType_Message;
        //Change the onscreen Text to reflect the current Dropdown selection
        //m_Text.text = TransferValue.routeType_Message;
    }
}
