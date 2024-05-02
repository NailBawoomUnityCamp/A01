using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRpg_MonsterHunting.Scene;

namespace TextRpg_MonsterHunting  //2024.05.02 박재우
{
    public class QuestInfo 
    {
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public int RewardGold { get; set; }
        public string RewardItem { get; set; }

        public class QuestInfo // 퀘스트 정보 클래스
        {
            public int Id { get; set; } // 퀘스트 ID
            public string Title { get; set; } // 퀘스트 제목
            public int RewardGold { get; set; } // 보상 골드
            public string RewardItem { get; set; } // 보상 아이템

            public QuestInfo(int id, string title, int rewardGold, string rewardItem) // 생성자
            {
                Id = id;
                Title = title;
                RewardGold = rewardGold;
                RewardItem = rewardItem;
            }
        }

        public class QuestManager // 퀘스트 관리자 클래스
        {
            private List<QuestInfo> quests; // 퀘스트 목록
            bool Quest_1_ing = false; // 퀘스트 1 진행 여부
            bool Quest_2_ing = false; // 퀘스트 2 진행 여부
            bool Quest_3_ing = false; // 퀘스트 3 진행 여부

            Quest quest = new Quest(); // 퀘스트 객체 생성
            Inventory inventory = new Inventory(); // 인벤토리 객체 생성
            Character character; // 캐릭터 객체

            public int MinionKillCount { get; set; }; // 미니언 처치 횟수

            public QuestManager() // 생성자
            {
                quests = new List<QuestInfo>() // 퀘스트 목록 초기화
            {
                new QuestInfo(1, "마을을 위협하는 미니언 처치", 5, "(아이템) x1"), // 퀘스트 정보 추가
            };
            }

            public QuestInfo GetQuestById(int id) // ID로 퀘스트 정보 가져오기
            {
                return quests.Find(quest => quest.Id == id);
            }

            public void QuestId1() // 퀘스트 1 메서드
            {
                if (Quest_1_ing = false) // 퀘스트가 진행 중이 아닐 때
                {
                    quest.Quest1S(); // 퀘스트 시작
                    string Input = Console.ReadLine(); // 사용자 입력 받기
                    switch (Input) // 사용자 입력에 따른 처리
                    {
                        case "1":
                            Quest_1_ing = true; // 퀘스트 진행 상태로 변경
                            MinionKillCount = 0; // 미니언 처치 횟수 초기화
                            break;
                        case "2":
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
                else // 퀘스트가 진행 중일 때
                {
                    if (MinionKillCount < 5) // 미니언 처치 횟수가 5 미만일 때
                    {
                        quest.Quest1R(); // 퀘스트 진행 중 메시지 출력
                        string Input = Console.ReadLine(); // 사용자 입력 받기
                        switch (Input) // 사용자 입력에 따른 처리
                        {
                            case "0":
                                break;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }
                    }
                    else // 미니언 처치 횟수가 5 이상일 때
                    {
                        quest.Quest1C(); // 퀘스트 완료 메시지 출력
                        string Input = Console.ReadLine(); // 사용자 입력 받기
                        switch (Input) // 사용자 입력에 따른 처리
                        {
                            case "1":
                                character.Gold += 5; // 골드 보상 지급
                                Console.WriteLine("보상을 수령하셨습니다."); // 보상 수령 메시지 출력
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
