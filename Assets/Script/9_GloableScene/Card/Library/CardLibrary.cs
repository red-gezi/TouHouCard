using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class CardLibrary : SerializedMonoBehaviour
{

    public static CardLibrary Instance;
    public GameObject Card_Model;
    public List<CardInfo> CardLibraryList = new List<CardInfo>();
    private void Awake()
    {
        Instance = this;
    }
}
