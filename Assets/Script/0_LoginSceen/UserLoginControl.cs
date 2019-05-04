﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static NetInfoModel;

public class UserLoginControl : MonoBehaviour
{
    public Text UserName;
    public Text Password;
    void Start()
    {
        Command.NetCommand.Init(NetClient.Client);
    }
    public void UserRegister()
    {
        GeneralCommand<int> msg = Command.NetCommand.Register(UserName.text, Password.text).ToObject<GeneralCommand<int>>();
        if (msg.Datas[0] == 1)
        {
            print("注册成功");
        }
        if (msg.Datas[0] == -1)
        {
            print("账号已存在");
        }
    }
    public void UserLogin()
    {
        GeneralCommand<string> msg = Command.NetCommand.Login(UserName.text, "123").ToObject<GeneralCommand<string>>();
        print(msg.Datas[1]);
        Info.AllPlayerInfo.Player1Info = msg.Datas[1].ToObject<PlayerInfo>();
        print(msg.Datas[0] == "1" ? "登录成功" : msg.Datas[1] == "-1" ? "密码错误" : "无此账号");
        Info.AllPlayerInfo.Player1Info = msg.Datas[1].ToObject<PlayerInfo>();
        SceneManager.LoadSceneAsync(1);
    }
}
