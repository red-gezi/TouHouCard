using Command;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static NetworkCommsDotNet.NetworkComms;

public class NetClient : MonoBehaviour
{
    static IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 495);
    static ConnectionInfo connInfo = new ConnectionInfo(ip);
    public static Connection Client = TCPConnection.GetConnection(connInfo);
  
    public static void Bind(string Tag, PacketHandlerCallBackDelegate<string> Func)
    {
        AppendGlobalIncomingPacketHandler(Tag, Func);
    }
}
