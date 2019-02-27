using NetworkCommsDotNet.Connections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class NetCommand
    {
        static Connection Client;
        public static void Init(Connection NetClient)
        {
            Client = NetClient;
        }
        public static string Register(string name, string password)
        {
            return Client.SendReceiveMessge("Regist", "RegistResult", new NetInfoModel.GeneralCommand<string>(name, password));
        }
        public static string Login(string name, string password)
        {
            return Client.SendReceiveMessge("Login", "LoginResult", new NetInfoModel.GeneralCommand<string>(name, password));
        }
        public static async Task<string> JoinRoomAsync()
        {
            NetInfoModel.PlayerInfo playerInfo = Info.PlayInfo.MyInfo;
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

