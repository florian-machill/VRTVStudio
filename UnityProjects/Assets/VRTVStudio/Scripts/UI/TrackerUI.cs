using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using TMPro;


/// <summary>
/// Displays the captured data
/// </summary>
public class TrackerUI : MonoBehaviour
{
    public static TrackerUI Instance;
       
    public TMP_Text positionsLabel;
    public TMP_Text rotationsLabel;
    

    void Awake()
    {
        Instance = this;
    }

    public void DisplayTrackingData(TrackerData data)
    {
        positionsLabel.text = "xPos:" + data.xPos + "\n\ryPos:" + data.yPos + "\n\rzPos:" + data.zPos;
        rotationsLabel.text = "xRot:" + data.xRot + "\n\ryRot:" + data.yRot + "\n\rzRot:" + data.zRot;
    }
       

}
