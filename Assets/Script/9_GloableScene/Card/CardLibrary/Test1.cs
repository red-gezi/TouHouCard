using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
[Obsolete()]
public class Test1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    [Button("创建")]
    private void NewMethod()
    {
        string OriginPath = Application.dataPath + @"\CardLibrary\CardModel\Card0.txt";
        for (int i = 1; i < 10; i++)
        {
            string NewPath = Application.dataPath + $@"\CardLibrary\CardModel\Card{i}.cs";
            string ScriptText = File.ReadAllText(OriginPath).Replace("0", i + "");
            File.Create(NewPath).Close();
            File.WriteAllText(NewPath, ScriptText);

        }

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
    [Button("load")]
    private void load()
    {
        Task.Run(async () =>
        {
            //CardBoardControl.Instance.LoadCardList(new List<int> { 1002, 1002 });
            await Task.Delay(2000);
        }).Wait();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


        }
    }
}
