using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CardLibraryCommand 
{
    public static void CreatScript(int id)
    {
        string OriginPath = Application.dataPath + @"\Script\9_GloableScene\Card\CardLibrary\CardModel\Card0.txt";
        string NewPath = Application.dataPath + $@"\Script\9_GloableScene\Card\CardLibrary\CardModel\Card{id}.cs";
        string ScriptText = File.ReadAllText(OriginPath).Replace("0", id + "");
        File.Create(NewPath).Close();
        File.WriteAllText(NewPath, ScriptText);
        AssetDatabase.Refresh();
    }
}
