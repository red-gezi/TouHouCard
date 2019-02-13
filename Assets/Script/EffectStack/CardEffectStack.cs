using Info;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Control
{
    public class CardEffectStackControl
    {
        public static async Task TriggerEffect<T>(Card Target) where T : Attribute
        {
            Stack<Func<Task>> TaskStack = new Stack<Func<Task>>();
            List<Func<Task>> Steps = new List<Func<Task>>();
            foreach (var item in Target.GetType().GetFields())
            {
                if (item.GetCustomAttributes(typeof(T), false).Length != 0)
                {
                    Steps.Add((Func<Task>)item.GetValue(Target));
                    Console.WriteLine("效果队列插入" + Target.GetType().Name.Replace("Unit", "卡牌") + "的阶段:" + item.Name);
                }
            }
            Steps.Reverse();
            Steps.ForEach(TaskStack.Push);
            while (TaskStack.Count != 0)
            {
                await TaskStack.Pop()();
            }
            GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task TriggerEffect<T>(List<Card> Targets) where T : Attribute
        {
            Stack<Func<Task>> TaskStack = new Stack<Func<Task>>();
            List<Func<Task>> Steps = new List<Func<Task>>();
            foreach (var Target in Targets)
            {
                foreach (var item in Target.GetType().GetFields())
                {
                    if (item.GetCustomAttributes(typeof(T), false).Length != 0)
                    {
                        Steps.Add((Func<Task>)item.GetValue(Target));
                        Console.WriteLine("效果队列插入" + Target.GetType().Name.Replace("Unit", "卡牌") + "的阶段:" + item.Name);
                    }
                }
                Steps.Reverse();
                Steps.ForEach(TaskStack.Push);
                Steps.Clear();
                while (TaskStack.Count != 0)
                {
                    await TaskStack.Pop()();
                }
            }
            GlobeBattleInfo.IsCardEffectCompleted = true;
        }
    }
}