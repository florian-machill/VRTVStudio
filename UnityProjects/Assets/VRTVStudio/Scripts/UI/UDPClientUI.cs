using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;

public enum ClientUIStates { None, Success, Fail }

public class UDPClientUI : MonoBehaviour
{
    public static UDPClientUI Instance;
    
    public TMP_InputField ipAdress;
    public TMP_InputField remotePort;
    public TMP_InputField clientPort;

    public TMP_Dropdown deviceSelection;
    public TMP_InputField interval;

    public Toggle syncToogle;

    public SteamVR_TrackedObject trackedObject;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Get saved values
        ipAdress.text = PlayerPrefs.GetString("ipAdress", "127.0.0.1");
        remotePort.text = PlayerPrefs.GetString("remotePort", "5500");
        clientPort.text = PlayerPrefs.GetString("clientPort", "5600");
        interval.text = PlayerPrefs.GetString("interval", "20");

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

    void OnDisable()
    {
        // Get saved values
        PlayerPrefs.SetString("ipAdress", ipAdress.text);
        PlayerPrefs.SetString("remotePort", remotePort.text);
        PlayerPrefs.SetString("clientPort", clientPort.text);
        PlayerPrefs.SetString("interval", interval.text);

        print("values saved!");
    }
   
    public UPDConnectionData GetData()
    {
        UPDConnectionData data = new UPDConnectionData();
        data.ipAddress = ipAdress.text;
        data.remotePort = int.Parse(remotePort.text);
        data.clientPort = int.Parse(clientPort.text);
        return data;
    }

    public int GetInterval()
    {
        return int.Parse(interval.text);
    }

    public bool ShouldSync()
    {
        return syncToogle.isOn;
    }

    private void OnTrackingDeviceSelected(TMP_Dropdown dropdown)
    {
        trackedObject.SetDeviceIndex(dropdown.value);
    }
}
