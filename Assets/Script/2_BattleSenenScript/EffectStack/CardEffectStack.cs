using CardSpace;
using Info;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Control
{
    public class CardEffectStackControl
    {
        public static Stack<Func<Task>> TaskStack = new Stack<Func<Task>>();
        public static bool IsRuning;
        public static async Task Run()
        {
            if (!IsRuning)
            {
                IsRuning = true;
                while (TaskStack.Count != 0)
                {
                    await TaskStack.Pop()();
                }
                IsRuning = false;
                GlobalBattleInfo.IsCardEffectCompleted = true;
            }
        }
        public static async Task TriggerCardList<T>(List<Card> Cards)
        {
            foreach (var card in Cards)
            {
                card.Trigger<T>();
            }
        }
        //public static async Task TriggerEffect<T>(Card Target) where T : Attribute
        //{
        //    Stack<Func<Task>> TaskStack = new Stack<Func<Task>>();
        //    List<Func<Task>> Steps = new List<Func<Task>>();
        //    foreach (var item in Target.GetType().GetFields())
        //    {
        //        if (item.GetCustomAttributes(typeof(T), false).Length != 0)
        //        {
        //            Steps.Add((Func<Task>)item.GetValue(Target));
        //            //Console.WriteLine("EffecyStack" + Target.GetType().Name.Replace("Unit", "c") + "step:" + item.Name);

        //        }
        //    }
        //    Steps.Reverse();
        //    Steps.ForEach(TaskStack.Push);
        //    while (TaskStack.Count != 0)
        //    {
        //        await TaskStack.Pop()();
        //    }
        //    GlobalBattleInfo.IsCardEffectCompleted = true;
        //}
        //public static async Task TriggerEffect<T>(List<Card> Targets) where T : Attribute
        //{
        //    Stack<Func<Task>> TaskStack = new Stack<Func<Task>>();
        //    List<Func<Task>> Steps = new List<Func<Task>>();
        //    foreach (var Target in Targets)
        //    {
        //        foreach (var item in Target.GetType().GetFields())
        //        {
        //            if (item.GetCustomAttributes(typeof(T), false).Length != 0)
        //            {
        //                Steps.Add((Func<Task>)item.GetValue(Target));
        //                //Console.WriteLine("EffecyStack" + Target.GetType().Name.Replace("Unit", "c") + "step:" + item.Name);
        //            }
        //        }
        //        Steps.Reverse();
        //        Steps.ForEach(TaskStack.Push);
        //        Steps.Clear();
        //        while (TaskStack.Count != 0)
        //        {
        //            await TaskStack.Pop()();
        //        }
        //    }
        //    GlobalBattleInfo.IsCardEffectCompleted = true;
        //}
    }
}