using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class QuestInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RewardGold { get; set; }
        public string RewardItem { get; set; }

        public QuestInfo(int id, string title, int rewardGold, string rewardItem)
        {
            Id = id;
            Title = title;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
        }
    }

    public class QuestManager
    {
        private List<QuestInfo> quests;
        bool Quest_1_ing = false;
        Quest quest = new Quest();
        Character character;

        public QuestManager()
        {
            quests = new List<QuestInfo>()
        {
            new QuestInfo(1, "마을을 위협하는 미니언 처치", 5, "(아이템) x1"),
            
            // 여기에 더 많은 퀘스트를 추가할 수 있습니다.
        };
        }

        public QuestInfo GetQuestById(int id)
        {
            return quests.Find(quest => quest.Id == id);
        }

        public void QuestId1()
        {
            if (Quest_1_ing = false)
            {
                quest.Quest1S();

                string Input = Console.ReadLine();

                switch (Input)
                {
                    case "1":
                        Quest_1_ing = true;
                        /* 미니언 처치수 0으로 초기화 */
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
            else
            {
                if (/* 미니언 처치가 5마리 미만일 때 */)
                {
                    quest.Quest1R();

                    string Input = Console.ReadLine();

                    switch (Input)
                    {
                        case "0":
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }

                else // 미니언 처치가 5마리 이상일 때
                {
                    quest.Quest1C();

                    string Input = Console.ReadLine();

                    switch (Input)
                    {
                        case "1":
                            // 보상추가
                            character.Gold += 5; // 5골드 추가 예시
                            Console.WriteLine("보상을 수령하셨습니다.")
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }
    }
}
