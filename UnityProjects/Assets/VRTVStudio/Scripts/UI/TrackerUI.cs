using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class TrackerUI : MonoBehaviour
{
    public TMP_Dropdown deviceSelection;

    public SteamVR_TrackedObject trackedObject;

    // Start is called before the first frame update
    void Start()
    {
        string[] devices = Enum.GetNames(typeof(SteamVR_TrackedObject.EIndex));

        for (int i = 0; i < devices.Length; i++)
        {            
            deviceSelection.options.Add(new TMP_Dropdown.OptionData(devices[i]));
        }

        deviceSelection.onValueChanged.AddListener(delegate {
            OnTrackingDeviceSelected(deviceSelection);
        });
    }

    private void OnTrackingDeviceSelected(TMP_Dropdown dropdown)
    {
        //SteamVR_TrackedObject.EIndex selected = 
        //(SteamVR_TrackedObject.EIndex) Enum.GetValues(typeof(SteamVR_TrackedObject.EIndex)).GetValue(dropdown.value);
        //print(selected);

        trackedObject.SetDeviceIndex(dropdown.value);
    }

}
