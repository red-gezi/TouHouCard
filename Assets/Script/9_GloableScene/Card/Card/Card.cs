﻿using Control;
using Info;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CardSpace
{
    public enum Property { Water, Fire, Wind, Soil, None ,All}
    public enum Territory { My, Op }
    public class Card : MonoBehaviour
    {
        public int CardId;
        public int CardPoint;
        public Texture2D icon;
        public bool IsMove;
        public bool IsTemp;
        public bool IsCanSee;
        public bool IsPrePrepareToPlay;
        bool IsInit;
        public Property CardProperty;
        public Territory CardTerritory;
        //public Card yaya;
        /// <summary>
        /// 限制卡牌被打出
        /// </summary>
        public bool IsLimit = true;
        public bool IsAutoMove => this != GlobalBattleInfo.PlayerPlayCard;
        public List<Card> Row => RowsInfo.GetRow(this);
        public Vector2 Location => RowsInfo.GetLocation(this);
        public Vector3 TargetPos;
        public Quaternion TargetRot;
        // public Text PointText;// = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        public Text PointText => transform.GetChild(0).GetChild(0).GetComponent<Text>();
        public void Init()
        {
            IsInit = true;
            PointText.text = CardPoint.ToString();
            //PointText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
            //print("yaya"+transform.GetChild(0).GetChild(0).GetComponent<Text>());
            //GetComponent<Renderer>().material.SetTexture("_Front", icon);
        }

        public void SetMoveTarget(Vector3 TargetPosition, Vector3 TargetEulers)
        {
            TargetPos = TargetPosition;
            TargetRot = Quaternion.Euler(TargetEulers + new Vector3(0, 0, IsCanSee ? 0 : 180));
            if (IsInit)
            {
                transform.position = TargetPos;
                transform.rotation = TargetRot;
                IsInit = false;
            }

        }
        public void RefreshState()
        {
            Material material = GetComponent<Renderer>().material;
            if (GlobalBattleInfo.PlayerFocusCard == this)
            {
                material.SetFloat("_IsFocus", 1);
                material.SetFloat("_IsRed", 0);
            }
            else if (GlobalBattleInfo.OpponentFocusCard == this)
            {
                material.SetFloat("_IsFocus", 1);
                material.SetFloat("_IsRed", 1);
            }
            else
            {
                material.SetFloat("_IsFocus", 0);
            }
            if (IsTemp)
            {
                material.SetFloat("_IsTemp", 0);
            }
            transform.position = new Vector3(transform.position.x, TargetPos.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRot, Time.deltaTime * 10);
        }
        public void Trigger<T>()
        {
            //Debug.Log(name + "触发" + typeof(T));
            List<Func<Task>> Steps = new List<Func<Task>>();
            //List<PropertyInfo> tasks = GetType().GetProperties().Where(x => x.GetCustomAttributes(true)[0].GetType() == typeof(T)).ToList();
            //GetType().GetProperties().ForEach(Debug.Log);
            //GetType().GetProperties().ForEach(x => Debug.Log("有标签的" + x.GetCustomAttributes(true)[0].GetType()));
            //Debug.Log("结束" );
            //Debug.Log("类型为" + typeof(T));
            List<PropertyInfo> tasks = GetType().GetProperties().Where(x => 
                x.GetCustomAttributes(true).Count()>0&& x.GetCustomAttributes(true)[0].GetType() == typeof(T)).ToList();
            //Debug.Log(name + "数量为" + tasks.Count);
            tasks.Reverse();
            tasks.Select(x => x.GetValue(this)).Cast<Func<Task>>().ToList().ForEach(CardEffectStackControl.TaskStack.Push);
            //Console.WriteLine("加载" + typeof(T));
            _ = CardEffectStackControl.Run();
        }
    }

}
