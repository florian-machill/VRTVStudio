using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UPDClient : MonoBehaviour
{
    public static UPDClient Instance;
    private UdpClient client;

    void Awake()
    {
        Instance = this;
    }

    public void UDPConnectionTest()
    {
        UPDConnectionData data = UDPClientUI.Instance.GetData();
        UDPClientUI.Instance.SetStatus(ClientUIStates.Fail);

        try
        {
            // Disconnect existing client
            if (client != null)
            {
                client.Close();
                client = null;
            }

            client = new UdpClient(data.clientPort);

            client.Connect(data.ipAddress, data.remotePort);
            byte[] sendBytes = Encoding.ASCII.GetBytes("Hello from client");
            client.Send(sendBytes, sendBytes.Length);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, data.remotePort);

            byte[] receivedBytes = client.Receive(ref remote);
            string receivedString = Encoding.ASCII.GetString(receivedBytes);

            print("Received server message: " + receivedString);
            UDPClientUI.Instance.SetStatus(ClientUIStates.Success);
        }
        catch (System.Exception e)
        {
            print("Exception: " + e.Message);
            UDPClientUI.Instance.SetStatus(ClientUIStates.Fail);
        }
    }

    public void SendTrackingData(TrackerData data)
    {
        UPDConnectionData connectionData = UDPClientUI.Instance.GetData();

        try
        {
            // Disconnect existing client
            if (client != null)
            {
                client.Close();
                client = null;
            }

            client = new UdpClient(connectionData.clientPort);

            client.Connect(connectionData.ipAddress, connectionData.remotePort);
            
            byte[] sendBytes =  new byte[24];
            BitConverter.GetBytes(data.xPos).CopyTo(sendBytes, 0);
            BitConverter.GetBytes(data.yPos).CopyTo(sendBytes, 4);
            BitConverter.GetBytes(data.zPos).CopyTo(sendBytes, 8);
            BitConverter.GetBytes(data.xRot).CopyTo(sendBytes, 12);
            BitConverter.GetBytes(data.yRot).CopyTo(sendBytes, 16);
            BitConverter.GetBytes(data.zRot).CopyTo(sendBytes, 20);

            print(BitConverter.ToString(sendBytes));

            client.Send(sendBytes, sendBytes.Length);


            UDPClientUI.Instance.SetStatus(ClientUIStates.Success);
        }
        catch (System.Exception e)
        {
            print("Exception: " + e.Message);
            UDPClientUI.Instance.SetStatus(ClientUIStates.Fail);
        }
    }
}
