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
        bool IsQuest1_ing = false;
        bool IsQuest1_Clear = false;

        private List<QuestInfo> quests;
        bool Quest_1_ing = false;
        bool Quest_1_Clear = false;
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
<<<<<<< Updated upstream
            if (IsQuest1_ing = false)
            {

            }
            else
            {
                if (/* 잡은 미니언 마릿수가 5마리 이상일 경우 */)
            }
        }

        // 필요에 따라 더 많은 메서드를 추가할 수 있습니다. 예) 모든 퀘스트 리스트 반환, 퀘스트 추가 등
=======
            if (Quest_1_ing = false)
            {
                quest.Quest1S();
>>>>>>> Stashed changes

                string Input = Console.ReadLine();

                switch (Input)
                {
                    case "1":
                        Quest_1_Clear = true;
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
                            QuestId1Clear();
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

        public void QuestId1Clear()
        {
            if (Quest_1_Clear = true)
            {
                character.Gold += 5; // 보상 추가
            }
        }
    }
}
