using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class ManaPotionQuest : Quest
    {
        public ManaPotionQuest(string title, int rewardGold, string rewardItem)
            : base(title, rewardGold, rewardItem) { }

        public override void QuestContent()
        {
            Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
            Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나? \n마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!");
            Console.WriteLine("\n\n미니언 5마리 처치 (0/5)");
            Console.WriteLine("\n보상");
            Console.WriteLine("마나 포션 x1, 5G");
            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");
        }
    }
}
