using Command;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Control
{
    public class StateControl : MonoBehaviour
    {
        void Start()
        {
            CardCommand.CreatCard(0);
            _ = BattleProcess();
            _ = PlayerSurrender();
        }
        public async Task BattleProcess()
        {
            await StateCommand.BattleStart();
            for (int i = 0; i < 3; i++)
            {
                await StateCommand.RoundStart(i);
                while (true)
                {
                    await StateCommand.TurnStart();
                    await StateCommand.WaitForPlayerOperation();
                    await StateCommand.TurnEnd();
                    if (StateCommand.IsAllPass()) { break; }
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
