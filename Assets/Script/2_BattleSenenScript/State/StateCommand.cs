using CardSpace;
using Control;
using Info;
using System.Threading.Tasks;
using UnityEngine;

namespace Command
{
    public class StateCommand
    {
        //static int num = 0;
        public static async Task BattleStart()
        {
            await Task.Run(async () =>
            {
                //await Task.Delay(500);
                NoticeControl.BoardNotice("对战开始");
                CardDeck Deck = AllPlayerInfo.Player1Info.UseDeck;

                for (int i = 0; i < Deck.CardIds.Count; i++)
                {
                    //print("我方创造卡片");
                    Card NewCard = await CardCommand.CreatCardAsync(Deck.CardIds[i]);
                    if (GlobalBattleInfo.IsPlayer1)
                    {
                        RowsInfo.GetDownCardList(RegionTypes.Deck).Add(NewCard);
                    }
                    else
                    {
                        RowsInfo.GetUpCardList(RegionTypes.Deck).Add(NewCard);
                    }
                    //NewCard.Init();
                }
                Deck = AllPlayerInfo.Player2Info.UseDeck;
                for (int i = 0; i < Deck.CardIds.Count; i++)
                {
                    //print("敌方创造卡片");
                    Card NewCard = await CardCommand.CreatCardAsync(Deck.CardIds[i]);
                    if (GlobalBattleInfo.IsPlayer1)
                    {
                        RowsInfo.GetUpCardList(RegionTypes.Deck).Add(NewCard);
                    }
                    else
                    {
                        RowsInfo.GetDownCardList(RegionTypes.Deck).Add(NewCard);
                    }
                }
                await Task.Delay(2000);
            });
            //print("结束对战准备");
        }
        public static async Task BattleEnd()
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice($"对战终止\n{GlobalBattleInfo.ShowScore.MyScore}:{GlobalBattleInfo.ShowScore.OpScore}");
                await Task.Delay(5000);
            });
        }
        public static async Task TurnStart()
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice((GlobalBattleInfo.IsMyTurn ? "我方" : "敌方") + "回合开始");
                GlobalBattleInfo.IsCardEffectCompleted = false;
                GameCommand.PlayCardLimit(!GlobalBattleInfo.IsMyTurn);
                await Task.Delay(1500);
            });
        }
        public static async Task TurnEnd()
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice((GlobalBattleInfo.IsMyTurn ? "我方" : "敌方") + "回合结束");
                GameCommand.PlayCardLimit(true);
                await Task.Delay(2000);
                GlobalBattleInfo.IsMyTurn = !GlobalBattleInfo.IsMyTurn;
            });
        }
        public static async Task RoundStart(int num)
        {
            await Task.Run(async () =>
            {
                GlobalBattleInfo.IsPlayer1Pass = false;
                GlobalBattleInfo.IsPlayer2Pass = false;
                PassCommand.ReSetPassState();
                NoticeControl.BoardNotice($"第{num + 1}小局开始");
                switch (num)
                {
                    case (0):
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                await CardCommand.DrawCard();
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                await CardCommand.DrawCard(false);
                            }
                            break;
                        }
                    default:
                        break;
                }
                await Task.Delay(2500);
            });
        }
        public static async Task RoundEnd(int num)
        {
            await Task.Run(async () =>
            {
                NoticeControl.BoardNotice($"第{num + 1}小局结束\n{PointInfo.TotalDownPoint}:{PointInfo.TotalUpPoint}\n{((PointInfo.TotalDownPoint > PointInfo.TotalUpPoint) ? "Win" : "Lose")}");
                int result = 0;
                if (PointInfo.TotalPlayer1Point > PointInfo.TotalPlayer2Point)
                {
                    result = 1;
                }
                else if (PointInfo.TotalPlayer1Point < PointInfo.TotalPlayer2Point)
                {
                    result = 2;
                }
                GlobalBattleInfo.PlayerScore.P1Score += result == 0 || result == 1 ? 1 : 0;
                GlobalBattleInfo.PlayerScore.P2Score += result == 0 || result == 2 ? 1 : 0;
                await Task.Delay(3500);
            });
        }

        public static async Task WaitForPlayerOperation()
        {
            await Task.Run(async () =>
            {
                //print("出牌");
                if (Info.GlobalBattleInfo.IsPVE && !Info.GlobalBattleInfo.IsMyTurn)
                {
                    await AiCommand.TempOperationAsync();
                }
                //当出牌,弃牌,pass时结束
                while (true)
                {
                    if (Info.GlobalBattleInfo.IsCardEffectCompleted)
                    {
                        break;
                    }
                    if (Info.GlobalBattleInfo.IsCurrectPass)
                    {
                        Info.GlobalBattleInfo.IsCardEffectCompleted = false;
                        break;
                    }
                    if (Info.GlobalBattleInfo.IsCardEffectCompleted)
                    {
                        Info.GlobalBattleInfo.IsCardEffectCompleted = false;
                        break;
                    }
                }
            });
        }
        public static async Task WaitForSelectRegion()
        {
            GlobalBattleInfo.IsWaitForSelectRegion = true;
            await Task.Run(() =>
            {
                while (Info.GlobalBattleInfo.SelectRegion == null) { }
            });
            GlobalBattleInfo.IsWaitForSelectRegion = false;
        }
        public static async Task WaitForSelectLocation()
        {
            GlobalBattleInfo.IsWaitForSelectLocation = true;
            RowCommand.SetRegionSelectable(true);
            await Task.Run(() =>
            {
                while (Info.GlobalBattleInfo.SelectLocation < 0) { }
            });
            RowCommand.SetRegionSelectable(false);
            GlobalBattleInfo.IsWaitForSelectLocation = false;
        }
        public static void SetPassState(bool IsPlayer1, bool IsActive)
        {
            if (IsPlayer1)
            {
                Debug.Log("我方pass啦" + IsActive);
                Info.UiInfo.Instance.MyPass.SetActive(IsActive);
            }
            else
            {
                Debug.Log("敌方pass啦" + IsActive);
                Info.UiInfo.Instance.OpPass.SetActive(IsActive);
            }
        }
        //public static bool IsAllPass()
        //{
        //    if (num < 3)
        //    {
        //        num++;
        //        return false;
        //    }
        //    else
        //    {
        //        num = 0;
        //        return true;
        //    }
        //}
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

