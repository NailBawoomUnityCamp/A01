using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class HealthPotionQuest : Quest
    {
        public HealthPotionQuest(string title, int rewardGold) 
            : base(title, rewardGold) 
        {
            RewardItem = ItemType.Health;
        }

        public override void QuestContent()
        {
            Console.WriteLine("\n== 장비 장착해보자 ==");
            Console.WriteLine("자네, 이제 장비를 장착해볼 때가 되었네. 자네가 가진 장비들을 살펴보게.");
            Console.WriteLine("\n보상");
            Console.WriteLine("체력 포션 x1, 5G");
            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");
        }
    }
}
