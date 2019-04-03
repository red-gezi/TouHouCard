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
            await CardCommand.DisCard(Info.GlobalBattleInfo.MyHand[0]);
        }
    }
}

