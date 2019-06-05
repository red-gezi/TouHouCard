using System;
using System.Threading.Tasks;
namespace Command
{
    public class AiCommand 
    {
        static Random rand = new Random("gezi".GetHashCode());
        public static void Init()
        {
            rand = new Random("gezi".GetHashCode());
        }

        public static int GetRandom(int Min, int Max)
        {
            
            return rand.Next(Min, Max);
        }

        /// <summary>
        /// 临时的ai操作
        /// </summary>
        /// <returns></returns>
        public static async Task TempOperationAsync()
        {
            if (Info.GlobalBattleInfo.IsPlayer1Pass || Info.GlobalBattleInfo.IsPlayer2Pass)
            {
                UiCommand.SetCurrentPass();
            }
            else
            {
                await CardCommand.DisCard(Info.RowsInfo.GetMyCardList(RegionTypes.Hand)[0]);
            }
        }


    }
}

