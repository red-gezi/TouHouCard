#if UNITY_EDITOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardMenu : OdinMenuEditorWindow
{


    [MenuItem("Tools/卡组编辑器")]
    private static void OpenWindow()
    {
        CardMenu window = GetWindow<CardMenu>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
    }
    private void OnInspectorUpdate()
    {
        ForceMenuTreeRebuild();

    }
    protected override OdinMenuTree BuildMenuTree()
    {

        CardLibrarySaveData SaveData = Resources.Load<CardLibrarySaveData>("SaveData");
        SaveData.Init();
        var tree = new OdinMenuTree(true);
        tree.DefaultMenuStyle.Height = 60;
        tree.DefaultMenuStyle.IconSize = 48.00f;
        tree.Config.DrawSearchToolbar = true;
        //CardModelInfo instance = new CardModelInfo();
        //tree.Add("卡组编辑", instance);
        tree.Add("卡牌列表", SaveData);
        if (SaveData.SingleCardLibrarieDatas != null)
        {
            foreach (var SingleLibrary in SaveData.SingleCardLibrarieDatas)
            {
                tree.Add($@"卡牌列表/{SingleLibrary.sectarian}", SingleLibrary);
                if (SingleLibrary.CardModelInfos != null)
                {
                    foreach (var CardModel in SingleLibrary.CardModelInfos)
                    {
                        //Debug.Log($@"卡牌列表/{SingleLibrary.sectarian}/{CardModel.CardName}");
                        tree.Add($@"卡牌列表/{SingleLibrary.sectarian}/{CardModel.CardName}", CardModel);
                    }
                }

            }
        }
        //for (int i = 0; i < SaveData.SingleCardLibrarieDatas.Count; i++)
        //{
        //    tree.Add($@"卡牌列表/{i}", SaveData.SingleCardLibrarieDatas[i]);
        //    for (int i = 0; i < SaveData.SingleCardLibrarieDatas[i].CardModelInfos.Count; i++)
        //    {
        //        tree.Add($@"卡牌列表/{i}", SaveData.SingleCardLibrarieDatas[i]);

        //    }
        //}
        tree.EnumerateTree().AddIcons<CardLibrarySaveData>(x => x.Icon);
        tree.EnumerateTree().AddIcons<CardLibrarySaveData.SingleCardLibrary>(x => x.Icon);
        tree.EnumerateTree().AddIcons<CardLibrarySaveData.SingleCardLibrary.CardModelInfo>(x => x.Icon);
        return tree;

    }
}
#endif