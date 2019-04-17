using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using static CardLibrarySaveData;

public class CardLibrary : SerializedMonoBehaviour
{

    public static CardLibrary Instance;
    public GameObject Card_Model;
    public List<SingleCardLibrary> CardLibraryList => Resources.Load<CardLibrarySaveData>("SaveData").SingleCardLibrarieDatas;
    private void Awake()
    {
        Instance = this;
        CardLibrarySaveData SaveData = Resources.Load<CardLibrarySaveData>("SaveData");
        
        //SaveData.SingleCardLibrarieDatas.
            
    }
    private void Start()
    {
    }

    private void AddComponent(string ClassName)
    {
        gameObject.AddComponent(Type.GetType(ClassName));
    }
}
