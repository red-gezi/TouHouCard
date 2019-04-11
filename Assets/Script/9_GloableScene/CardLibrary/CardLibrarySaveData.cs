using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "SaveData", menuName = "Creat SaveData Asset")]

public class CardLibrarySaveData : ScriptableObject
{
    [LabelText("牌库图标")]
    public Texture2D Icon;
    [ShowInInspector]
    [LabelText("牌库卡牌数量")]
    public int CardNum;
    public List<SingleCardLibrary> SingleCardLibrarieDatas;
    public void Init()
    {
        CardNum = SingleCardLibrarieDatas.Select(Cards => Cards.CardNum).Sum();
    }
    [Button("添加势力")]
    public void AddSingleCardLibrary()
    {
        if (SingleCardLibrarieDatas == null)
        {
            SingleCardLibrarieDatas = new List<SingleCardLibrary>();
        }
        SingleCardLibrarieDatas.Add(new SingleCardLibrary());
    }
    [Serializable]
    public class SingleCardLibrary
    {
        [HideLabel, PreviewField(55, ObjectFieldAlignment.Right)]
        [HorizontalGroup("Split", 55, LabelWidth = 70)]
        public Texture2D Icon;

        [VerticalGroup("Split/Meta")]
        [LabelText("当前卡牌数量")]
        public int CardNum;

        [TabGroup("卡片制作")]
        [HideLabel, PreviewField(128, ObjectFieldAlignment.Right)]
        public Texture2D icon;

        [TabGroup("卡片制作")]
        [LabelText("所属势力")]
        public Sectarian sectarian;

        [TabGroup("卡片制作")]
        [LabelText("卡片名称")]
        public string CardName;

        [TabGroup("卡片制作")]
        public int Point;

        [TabGroup("卡片制作")]
        [Button("添加卡牌")]
        public void AddCardModely()
        {
            //卡牌添加条件，暂时为名字不为空
            if (CardName!="")
            {
                if (CardModelInfos == null)
                {
                    CardModelInfos = new List<CardModelInfo>();
                }
                int NewCardId = int.Parse($"{10}{(int)sectarian}{CardModelInfos.Count}");
                CardLibraryCommand.CreatScript(NewCardId);
                CardModelInfos.Add(new CardModelInfo(icon, NewCardId, CardName, Point, sectarian));
                CardNum = CardModelInfos.Count;
            }
           
        }

        [TabGroup("卡片管理")]
        public List<CardModelInfo> CardModelInfos;

        [Serializable]
        public class CardModelInfo
        {
            [HorizontalGroup("Split", 55, LabelWidth = 70)]
            [HideLabel, PreviewField(55, ObjectFieldAlignment.Right)]
            //[LabelText("卡片贴图")]
            public Texture2D Icon;
            [VerticalGroup("Split/Meta")]
            [LabelText("ID")]
            public int CardId;
            [VerticalGroup("Split/Meta")]
            [LabelText("名字")]
            public string CardName;
            [VerticalGroup("Split/Meta")]
            [LabelText("点数")]
            public int Point;
            [VerticalGroup("Split/Meta")]
            [LabelText("所属势力")]
            public Sectarian sectarian;

            public CardModelInfo(Texture2D icon, int cardId, string cardName, int point, Sectarian sectarian)
            {
                Icon = icon;
                CardId = cardId;
                CardName = cardName;
                Point = point;
                this.sectarian = sectarian;
            }

            [Button("打开脚本")]
            public void OpenCardScript()
            {
                string NewPath = Application.dataPath + $@"\Script\9_GloableScene\CardLibrary\CardModel\Card{CardId}.cs";
                Process.Start(NewPath);
            }
        }
    }
}


public enum Sectarian
{
    道教,
    神道教,
    佛教,
    中立
}