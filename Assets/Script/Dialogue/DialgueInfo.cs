using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialgueInfo : MonoBehaviour
{
    public static DialgueInfo DialgueInfos;
    public GameObject Left;
    public GameObject Right;
    public Text Text;
    public bool IsNext;
    public enum Chara
    {
        灵梦A,
        灵梦B,
        早苗
    }
    public class Dial : Attribute
    {
        public int step;
        public int rank;

        public Dial(int step, int rank)
        {
            this.step = step;
            this.rank = rank;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        DialgueInfos = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
