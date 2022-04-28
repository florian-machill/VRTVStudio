using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class TrackerUI : MonoBehaviour
{
    public static TrackerUI Instance;
    public TMP_Dropdown deviceSelection;

    public TMP_Text positionsLabel;
    public TMP_Text rotationsLabel;

    public SteamVR_TrackedObject trackedObject;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Fill drop down with SteamVR Devices
        string[] devices = Enum.GetNames(typeof(SteamVR_TrackedObject.EIndex));
        for (int i = 0; i < devices.Length; i++)
        {
            deviceSelection.options.Add(new TMP_Dropdown.OptionData(devices[i]));
        }

        deviceSelection.onValueChanged.AddListener(delegate
        {
            OnTrackingDeviceSelected(deviceSelection);
        });
    }

    public void DisplayTrackingData(TrackerData data)
    {
        positionsLabel.text = "xPos: " + data.xPos + ", yPos: " + data.yPos + ", zPos: " + data.zPos;
        rotationsLabel.text = "xRot: " + data.xRot + ", yRot: " + data.yRot + ", zRot: " + data.zRot;
    }

    private void OnTrackingDeviceSelected(TMP_Dropdown dropdown)
    {
        //SteamVR_TrackedObject.EIndex selected = 
        //(SteamVR_TrackedObject.EIndex) Enum.GetValues(typeof(SteamVR_TrackedObject.EIndex)).GetValue(dropdown.value);
        //print(selected);

        trackedObject.SetDeviceIndex(dropdown.value);
    }

}
