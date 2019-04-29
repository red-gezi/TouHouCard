using CardSpace;
using Command;
using Info;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test
{
    public class TestScript : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(4))
            {
                Card NewCard = CardCommand.CreatCard(1001);
                NewCard.Trigger<TriggerType.Deploy>();
                //RowsInfo.GetRegionCardList(RegionName_Battle.My_Water).Add(NewCard);
                //GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
                //print(NewCard.name);
            }
            if (Input.GetMouseButtonDown(3))
            {
                //CardCommand.DrawCard();

                //Card b = a.ThisRowCard[0];
                //a.ThisRowCard.Remove(b);
                //Destroy(b.gameObject);
            }
        }
    }

}
