using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static NetworkCommsDotNet.NetworkComms;

namespace Command
{
    public class NetCommand
    {
        static Connection Client;
        //监听
        public static void Bind(string Tag, PacketHandlerCallBackDelegate<string> Func)
        {
            AppendGlobalIncomingPacketHandler(Tag, Func);
        }
        public static void Init(Connection NetClient)
        {
            Client = NetClient;
            Bind("JoinResult", JoinResult);
        }

        private static void JoinResult(PacketHeader packetHeader, Connection connection, string data)
        {
            Info.AllPlayerInfo.OpInfo = data.ToObject<NetInfoModel.PlayerInfo>();
            SceneManager.LoadSceneAsync(2);
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
            Client.SendMessge("Join", new NetInfoModel.GeneralCommand(Info.AllPlayerInfo.MyInfo));
        }
        [Obsolete]
        public static async Task<string> JoinRoomAsync()
        {
            NetInfoModel.PlayerInfo playerInfo = Info.AllPlayerInfo.MyInfo;
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

