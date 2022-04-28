using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UPDClient : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";
    public int remotePort = 5500;
    public int clientPort = 5600;
    private UdpClient client;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UDPConnectionTest()
    {
        UPDConnectionData data = UDPClientUI.Instance.GetData();
        print(data);
        try
        {
            

            if(client!=null)
            {
                client.Close();
                client = null;
            }

            client = new UdpClient(data.clientPort);
            
            client.Connect(ipAddress, data.remotePort);
            byte[] sendBytes = Encoding.ASCII.GetBytes("Hello from client");
            client.Send(sendBytes, sendBytes.Length);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, data.remotePort);

            byte[] receivedBytes = client.Receive(ref remote);
            string receivedString = Encoding.ASCII.GetString(receivedBytes);

            print("Received server message: " + receivedString);
        }
        catch (System.Exception e)
        {            
            print("Exception: "+e.Message);
        }
    }
}
