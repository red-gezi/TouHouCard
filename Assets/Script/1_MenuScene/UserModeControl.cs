using UnityEngine;
using UnityEngine.SceneManagement;

public class UserModeControl : MonoBehaviour
{
    public static bool IsJoinRoom = false;
    void Update()
    {
        if (IsJoinRoom)
        {
            SceneManager.LoadSceneAsync(2);
            IsJoinRoom = false;
        }
    }
    public void JoinRoom()
    {
        Command.NetCommand.JoinRoom();
    }
}
