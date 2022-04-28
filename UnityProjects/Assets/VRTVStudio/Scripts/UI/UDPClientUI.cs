using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ClientUIStates { None, Success, Fail }

public class UDPClientUI : MonoBehaviour
{
    public static UDPClientUI Instance;
    public TMP_InputField ipAdress;
    public TMP_InputField remotePort;
    public TMP_InputField clientPort;

    public Image status;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetStatus(ClientUIStates.None);
    }

    public void SetStatus(ClientUIStates state)
    {
        switch (state)
        {
            case ClientUIStates.None:
                status.color = Color.gray;
                break;
            case ClientUIStates.Success:
                status.color = Color.green;
                break;
            case ClientUIStates.Fail:
                status.color = Color.red;
                break;
            default:
                status.color = Color.gray;
                break;
        }
    }

    public UPDConnectionData GetData()
    {
        UPDConnectionData data = new UPDConnectionData();
        data.ipAddress = ipAdress.text;
        data.remotePort = int.Parse(remotePort.text);
        data.clientPort = int.Parse(clientPort.text);
        return data;
    }
}
