using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class QuestManager
    {
        public static QuestManager Instance;
        public List<Quest> Quests;

        public QuestManager()
        {
            if (Instance == null)
                Instance = new QuestManager();
            else
                Instance = this;

            Quests = new List<Quest>();
            Quests.Add(new ManaPotionQuest("마을을 위협하는 미니언 처치", 5));
            Quests.Add(new HealthPotionQuest("장비 장착해보자", 5));
            Quests.Add(new AttackItemQuest("더욱 더 강해지기!", 5));
        }

        public void CheckQuestCompletion(Character character)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.IsAccept && quest.IsClear)
                {
                    switch (quest.RewardItem)
                    {
                        case ItemType.Mana:
                            character.inventory.Add(Utils.ManaPotion);
                            character.ChangeGold(5);
                            break;
                        case ItemType.Health:
                            character.inventory.Add(Utils.HealthPotion);
                            character.ChangeGold(5);
                            break;
                        case ItemType.Attack:
                            character.inventory.Add(Utils.Sword);
                            character.ChangeGold(5);
                            break;
                    }
                }
            }
        }

        /*private List<QuestInfo> quests;
        bool Quest_1_ing = false;
        bool Quest_2_ing = false;
        bool Quest_3_ing = false;

        Quest quest = new Quest();
        Inventory inventory = new Inventory();
        Character character;

        public int MinionKillCount { get; set; };

        public QuestManager()
        {
            quests = new List<QuestInfo>()
        {
            new QuestInfo(1, "마을을 위협하는 미니언 처치", 5, "(아이템) x1"),

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
                        MinionKillCount = 0; // 미니언 처치수 0으로 초기화
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
                if (MinionKillCount < 5) // 미니언 처치가 5마리 미만일 때
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

        public void QuestId2()
        {
            if (!Quest_2_ing)
            {
                quest.Quest2S();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Quest_2_ing = true;
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
            else // 퀘스트가 진행중일때
            {
                if (inventory.EquipmentsInBag = false)
                {
                    quest.Quest2R();

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "0":
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }

                else // 클리어 조건까지 만족했을때 
                {
                    quest.Quest2C();

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            // 보상

                            Quest_2_ing = false;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }

        public void QuestId3()
        {
            if (!Quest_3_ing)
            {
                quest.Quest3S();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // 현재 플레이어의 레벨을 새로운 변수로 저장
                        Quest_3_ing = true;
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
                if (변수에 저장되있는 값과 현재 레벨값이 같을 때)
                {
                    quest.Quest3R();

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "0":
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }

                else // 변수에 저장되있는 값이 현재 레벨값보다 높을때
                {
                    quest.Quest3C();

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            // 보상
                            // 현제 플레이어의 레벨을 새로운 변수에 저장한걸 초기화시킴.
                            Quest_3_ing = false;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }*/
    }
}
