using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UPDConnectionData
{
    public string ipAddress;
    public int remotePort;
    public int clientPort;

    public override string ToString()
    {
        return ipAddress + " | " + remotePort + " | " + clientPort;
    }
}
