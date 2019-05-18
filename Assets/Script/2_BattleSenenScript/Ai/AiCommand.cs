using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class AiCommand : MonoBehaviour
    {
        /// <summary>
        /// 临时的ai操作
        /// </summary>
        /// <returns></returns>
        public static async Task TempOperationAsync()
        {
            if (Info.GlobalBattleInfo.IsPlayer1Pass|| Info.GlobalBattleInfo.IsPlayer2Pass)
            {
                Command.PassCommand.SetCurrentPass();
            }
            else
            {
                await CardCommand.DisCard(Info.RowsInfo.GetMyCardList(RegionTypes.Hand)[0]);
            }
        }
    }
}

