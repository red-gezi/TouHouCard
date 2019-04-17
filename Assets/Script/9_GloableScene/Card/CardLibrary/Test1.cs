using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

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
        AssetDatabase.Refresh();
    }
    [Button("load")]
    private void load()
    {
        for (int i = 1; i < 10; i++)
        {
            gameObject.AddComponent(Type.GetType($"Card{i}"));
            //gameObject.AddComponent(Type.GetType("Card1"));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CardLibrarySaveData saveData = Resources.Load<CardLibrarySaveData>("SaveData");
            print(JsonUtility.ToJson(saveData));
        }
    }
}
