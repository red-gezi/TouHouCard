using CardSpace;
using Command;
using Info;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static NetInfoModel;

namespace Control
{
    [Obsolete]
    public class CardInstanceControl : MonoBehaviour
    {
        [Obsolete]
        public static bool ShouldCreatCard;
        [Obsolete]
        public static Card CreatCard;
        [Obsolete]
        public static int CreatID;

        void Update()
        {
            Creatcard();
        }
        [Obsolete]
        private static void Creatcard()
        {
            if (ShouldCreatCard)
            {
                CreatCard = CardCommand.CreatCard(CreatID);
                CreatID = -1;
                ShouldCreatCard = false;
            }
        }
    }
}

