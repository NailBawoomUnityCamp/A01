using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRpg_MonsterHunting.Scene;

namespace TextRpg_MonsterHunting
{
    public class QuestInfo //2024.05.02 박재우
    {
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public int RewardGold { get; set; }
        public string RewardItem { get; set; }


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
                if (/* 변수에 저장되있는 값과 현재 레벨값이 같을 때 */)
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
        }
    }
}
