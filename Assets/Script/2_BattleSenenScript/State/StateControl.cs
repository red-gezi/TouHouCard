using Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Control
{
    public class StateControl : MonoBehaviour
    {
        bool IsLastPlay1Pass = false;
        bool IsLastPlay2Pass = false;
        void Start()
        {
            _ = BattleProcess();
            //PlayerSurrender().Catch();
        }
        private void Update()
        {
            CheckPassState();
        }

        private void CheckPassState()
        {
            //当pass状态发生改变时
            if (IsLastPlay1Pass ^ Info.GlobalBattleInfo.IsPlayer1Pass)
            {
                IsLastPlay1Pass = Info.GlobalBattleInfo.IsPlayer1Pass;
                StateCommand.SetPassState(Info.GlobalBattleInfo.IsPlayer1, Info.GlobalBattleInfo.IsPlayer1Pass);
            }
            if (IsLastPlay2Pass ^ Info.GlobalBattleInfo.IsPlayer2Pass)
            {
                IsLastPlay2Pass = Info.GlobalBattleInfo.IsPlayer2Pass;
                StateCommand.SetPassState(!Info.GlobalBattleInfo.IsPlayer1, Info.GlobalBattleInfo.IsPlayer2Pass);
            }
        }

        public async Task BattleProcess()
        {
            Info.AllPlayerInfo.Player1Info = new NetInfoModel.PlayerInfo("gezi", "yaya", new List<CardDeck> { new CardDeck("gezi", 0, new List<int> { 1000, 1001, 1002, 1001, 1000, 1002, 1000, 1001, 1000, 1001 }) });
            Info.AllPlayerInfo.Player2Info = new NetInfoModel.PlayerInfo("gezi", "yaya", new List<CardDeck> { new CardDeck("gezi", 0, new List<int> { 1001, 1001, 1000, 1000, 1001, 1001, 1000, 1000, 1001, 1001 }) });
            await StateCommand.BattleStart();
            for (int i = 0; i < 3; i++)
            {
                await StateCommand.RoundStart(i);
                while (true)
                {
                    await StateCommand.TurnStart();
                    await StateCommand.WaitForPlayerOperation();
                    await StateCommand.TurnEnd();
                    if (Info.GlobalBattleInfo.IsBoothPass) { break; }
                }
                await StateCommand.RoundEnd(i);
            }
            await StateCommand.BattleEnd();
        }
        public async Task PlayerSurrender()
        {
            await StateCommand.Surrender();
        }
    }

}
