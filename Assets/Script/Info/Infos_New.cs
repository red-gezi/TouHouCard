using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos_New : MonoBehaviour
{
    //public static
    //public static UIInfo UIInfos;
    //public static CardInfo CardInfos;
    //public static SceneInfo SceneInfos;
    //public static BattleInfo BattlesInfos;
    //public static PlayerInfo PlayerInfos;
    //public static SelectInfo SelectInfos;
    //public static GlobeCardInfo GlobeCardInfos;
    // Start is called before the first frame update
    void Start()
    {
        InitUserInfo();
    }
    //delegate void GeziAction(Card_N text1 = , string text2 = "is ", string text3 = "baka");

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 初始化用户相关信息引用
    /// </summary>
    public void InitUserInfo()
    {
        //BattlesInfos = BattleInfo.Instance;
        //CardInfos = CardInfo.Instance;
        //GlobeCardInfos = GlobeCardInfo.Instance;
        //SceneInfos = SceneInfo.Instance;
        //PlayerInfos = PlayerInfo.Instance;
    }
    /// <summary>
    /// 初始化对局相关信息引用
    /// </summary>
    public void InitBattleInfo()
    {

    }
}
