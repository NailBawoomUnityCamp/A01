using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class AttackItemQuest : Quest
    {
        public AttackItemQuest(string title, int rewardGold, string rewardItem) 
            : base(title, rewardGold, rewardItem) { }

        public override void QuestContent()
        {
            Console.WriteLine("\n== 더욱 더 강해지기! ==");
            Console.WriteLine("자네, 이제 더욱 강해질 때가 되었네. 경험치를 쌓아 레벨업을 해보게.");
            Console.WriteLine("\n보상");
            Console.WriteLine("단검 x1, 5G");
            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");
        }
    }
}
