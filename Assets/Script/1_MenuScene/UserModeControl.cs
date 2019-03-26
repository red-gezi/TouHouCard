using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserModeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void JoinRoom()
    {
        Command.NetCommand.JoinRoom();
        //Task.Run(async () =>
        //{
        //    var s = await Command.NetCommand.JoinRoomAsync();
        //    print("加入结果是" + s);
        //    SceneManager.LoadSceneAsync(2);

        //});
    }
}
