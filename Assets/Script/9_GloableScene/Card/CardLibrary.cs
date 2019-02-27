using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLibrary : SerializedMonoBehaviour
{

    public static CardLibrary Instance;
    public GameObject Card_Model;
    public List<Card> CardLibraryList = new List<Card>();
    private void Awake()
    {
        Instance = this;
    }
}
