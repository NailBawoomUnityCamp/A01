using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class Quest //2024.05.02 박재우
    {
    {
        QuestManager questManager = new QuestManager();

        public void Quest1S()
        {
            Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
            Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나? \n마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!");
            Console.WriteLine("\n\n미니언 5마리 처치 (0/5)");
            Console.WriteLine("\n보상");
            Console.WriteLine("(아이템) x1, 5G");
            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");
        }

        public void Quest1R()
        {
            Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
            Console.WriteLine($"미니언을 잡는데에 문제는 없는가? \n지금 당신이 잡은 미니언은 {questManager.MinionKillCount} / 5 마리네.");
            Console.WriteLine("\n보상");
            Console.WriteLine("(아이템) x 1 , 5G");
            Console.WriteLine("0. 돌아가기");
        }

        public void Quest1C()
        {
            Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
            Console.WriteLine("모든 미니언을 토벌해줘서 고맙네!\n보상을 수령해가게!");
            Console.WriteLine("\n보상");
            Console.WriteLine("(아이템) x 1 , 5G");
            Console.WriteLine("1. 보상 수령");
            Console.WriteLine("0. 돌아가기");
        }
    }
}