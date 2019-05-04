using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Threading.Tasks;
using UnityEngine;
using static NetworkCommsDotNet.NetworkComms;

namespace Command
{
    public class NetCommand
    {
        static Connection Client;
        public static void Bind(string Tag, PacketHandlerCallBackDelegate<string> Func)
        {
            AppendGlobalIncomingPacketHandler(Tag, Func);
        }
        public static void Init(Connection NetClient)
        {
            Client = NetClient;
            Debug.Log("绑定");
            Bind("JoinResult", JoinResult);
        }
        private static void JoinResult(PacketHeader packetHeader, Connection connection, string data)
        {
            Debug.Log("触发");
            Info.AllPlayerInfo.Player2Info = data.ToObject<NetInfoModel.PlayerInfo>();
            Debug.Log(Info.AllPlayerInfo.Player1Info.ToJson());
            Debug.Log(Info.AllPlayerInfo.Player2Info.ToJson());
            UserModeControl.IsJoinRoom = true;
        }
        public static string Register(string name, string password)
        {
            return Client.SendReceiveMessge("Regist", "RegistResult", new NetInfoModel.GeneralCommand<string>(name, password));
        }
        public static string Login(string name, string password)
        {
            return Client.SendReceiveMessge("Login", "LoginResult", new NetInfoModel.GeneralCommand<string>(name, password));
        }
        public static void JoinRoom()
        {
            Client.SendMessge("Join", Info.AllPlayerInfo.Player1Info);
        }
        [Obsolete]
        public static async Task<string> JoinRoomAsync()
        {
            NetInfoModel.PlayerInfo playerInfo = Info.AllPlayerInfo.Player1Info;
            string Msg = "";
            await Task.Run(() =>
             {
                 try
                 {
                     Msg = Client.SendReceiveMessge("Join", "JoinResult", new NetInfoModel.GeneralCommand(playerInfo), 5);
                 }
                 catch (Exception)
                 {
                     Msg = "连接超时";
                 }
             });
            return Msg;
        }
    }
}

