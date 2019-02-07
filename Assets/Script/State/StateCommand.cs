using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
namespace Command
{
    public class StateCommand : MonoBehaviour
    {
        static int num = 0;
        public static async Task TurnStart()
        {
            await Task.Run(async () =>
            {
                Info.GlobeBattleInfo.IsCardEffectCompleted = false;
                

                print("回合" + "开始");
                await Task.Delay(500);
            });
        }
        public static async Task TurnEnd()
        {
            await Task.Run(async () =>
            {
                print("回合" + "结束");
                await Task.Delay(500);
            });
        }
        public static async Task RoundStart(int num)
        {
            await Task.Run(async () =>
            {
                Info.GlobeBattleInfo.IsPlayer1Pass = false;
                Info.GlobeBattleInfo.IsPlayer2Pass = false;
                print("小局" + "开始");
                await Task.Delay(500);
            });
        }
        public static async Task RoundEnd(int num)
        {
            await Task.Run(async () =>
            {
                print("小局" + "结束");
                await Task.Delay(500);
            });
        }
        public static async Task BattleStart()
        {
            await Task.Run(async () =>
            {
                print("对战" + "开始");
                await Task.Delay(500);
            });
        }
        public static async Task BattleEnd()
        {
            await Task.Run(async () =>
            {
                print("对战" + "结束");
                await Task.Delay(500);
            });
        }
        public static async Task WaitForPlayerOperation()
        {
            await Task.Run(async () =>
            {
                //当出牌,弃牌,pass时结束
                print("出牌");
                while (true)
                {
                    if (Info.GlobeBattleInfo.IsCardEffectCompleted)
                    {                  
                        break;
                    }
                    if (Info.GlobeBattleInfo.IsCurrectPass)
                    {
                        Info.GlobeBattleInfo.IsCardEffectCompleted = false;
                        break;
                    }
                    if (Info.GlobeBattleInfo.IsCardEffectCompleted)
                    {
                        Info.GlobeBattleInfo.IsCardEffectCompleted = false;
                        break;
                    }
                }
                print("结束效果");

            });
        }
        public static bool IsAllPass()
        {
            if (num < 3)
            {
                print("第" + num + "小局");
                num++;
                return false;
            }
            else
            {
                num = 0;
                return true;
            }

        }
        public static async Task Surrender()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (false)
                    {
                        await BattleEnd();
                    }
                }

            });
        }
    }
}

