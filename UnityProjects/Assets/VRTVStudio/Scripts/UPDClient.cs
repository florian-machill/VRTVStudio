using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UPDClient : MonoBehaviour
{
    private UdpClient client;

    public void UDPConnectionTest()
    {
        UPDConnectionData data = UDPClientUI.Instance.GetData();
        UDPClientUI.Instance.SetStatus(ClientUIStates.Fail);

        try
        {
            // Disconnect existing client
            if(client!=null)
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
            print("Exception: "+e.Message);
            UDPClientUI.Instance.SetStatus(ClientUIStates.Fail);
        }
    }
}
