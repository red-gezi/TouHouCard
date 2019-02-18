using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using Info;
using Control;
namespace Command
{
    public class StateCommand : MonoBehaviour
    {
        static int num = 0;
        public static async Task TurnStart()
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice("回合开始");
                Info.GlobeBattleInfo.IsCardEffectCompleted = false;
               // print("回合" + "开始");
                GameCommand.PlayCardLimit(false);
                await Task.Delay(500);
            });
        }
        public static async Task TurnEnd()
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice("回合结束");

                GameCommand.PlayCardLimit(true);

                await Task.Delay(2000);
            });
        }
        public static async Task RoundStart(int num)
        {
            await Task.Run(async () =>
            {
                Info.GlobeBattleInfo.IsPlayer1Pass = false;
                Info.GlobeBattleInfo.IsPlayer2Pass = false;
                NoticeControl.BoardNotice("小局开始");

                switch (num)
                {
                    case (0):
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                await CardCommand.DrawCard();
                            }
                            break;
                        }
                    default:
                        break;
                }
                await Task.Delay(500);
            });
        }
        public static async Task RoundEnd(int num)
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice("小局结束");

                await Task.Delay(500);
            });
        }
        public static async Task BattleStart()
        {
            await Task.Run(async () =>
            {
                //await Task.Delay(500);
                NoticeControl.BoardNotice("对战开始");
                CardDeck Deck = PlayInfo.Instance.MyDeck;
                for (int i = 0; i < Deck.CardID.Count; i++)
                {
                    //print("生成一张牌");
                    Card NewCard =await CardCommand.CreatCardAsync(Deck.CardID[i]);
                    RowsInfo.GetRegionCardList(RegionName_Other.My_Deck).Add(NewCard);
                    NewCard.Init();
                }
                Deck = PlayInfo.Instance.OpDeck;
                for (int i = 0; i < Deck.CardID.Count; i++)
                {
                    //print("生成一张牌");
                    Card NewCard = await CardCommand.CreatCardAsync(Deck.CardID[i]);
                    RowsInfo.GetRegionCardList(RegionName_Other.Op_Deck).Add(NewCard);
                    NewCard.Init();
                }
                await Task.Delay(2000);
            });
        }
        public static async Task BattleEnd()
        {
            await Task.Run(async () =>
            {
                //print("对战" + "结束");
                await Task.Delay(500);
            });
        }
        public static async Task WaitForPlayerOperation()
        {
            await Task.Run(async () =>
            {
                //当出牌,弃牌,pass时结束
                //print("出牌");
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
                //print("结束效果");

            });
        }
        public static bool IsAllPass()
        {
            if (num < 3)
            {
                //print("第" + num + "小局");
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

