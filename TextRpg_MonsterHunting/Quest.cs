using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
   public class Quest
    {
        Character character;
        // 던전 값을 가져오는 생성자 추가
        private bool QuestAccepted1 = false; // 퀘스트 수락 여부 체크

        public void QuestUI()
        {
            bool IsQuest = true;

            while (IsQuest)
            {
                Console.WriteLine("\n== 퀘스트 목록 ==");
                Console.WriteLine("\n1. 마을을 위협하는 미니언 처치");
                Console.WriteLine("2. 장비를 장착해보자");
                Console.WriteLine("3. 더욱 더 강해지기!");
                Console.WriteLine("\n0. 뒤로가기");

                Console.Write("\n원하시는 퀘스트를 선택해주세요.\n>> ");
                string? Input = Console.ReadLine();

                switch (Input)
                {
                    case "1":
                        Quest1();
                        break;
                    case "2":
                        // 2번 퀘스트 메소드
                        break;
                    case "3":
                        // 3번 퀘스트 메소드
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        public void Quest1()
        {
            bool isQuest1 = true;

            while (isQuest1)
            {
                if (QuestAccepted1 = false)
                {
<<<<<<< Updated upstream
                    Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
                    Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나? \n마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!");
                    Console.WriteLine("\n\n미니언 5마리 처치 (0/5)");
                    Console.WriteLine("\n보상");
                    Console.WriteLine("(아이템) x1, 5G");
                    Console.WriteLine("1. 수락");
                    Console.WriteLine("2. 거절");
=======
                    
>>>>>>> Stashed changes

                    Console.WriteLine("\n원하시는 행동을 입력해주세요. >>");
                    string? Input = Console.ReadLine();

                    switch (Input)
                    {
                        case "1":
                            QuestAccepted1 = true;
                            isQuest1 = false;
                            break;
                        case "2":
                            //퀘스트거절
                            isQuest1 = false;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
                else
                {
                    if (/* 미니언 카운트가 5 미만 일때 */)
                    {
                        Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
                        Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나? \n마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!");
                        Console.WriteLine($"\n\n미니언 5마리 처치 ({/* 미니언 카운트 */}/5)");
                        Console.WriteLine("\n보상");
                        Console.WriteLine("(아이템) x1, 5G");

                        Console.WriteLine("0. 돌아가기");

                        Console.WriteLine("\n원하시는 행동을 입력해주세요. >>");
                        string? Input = Console.ReadLine();

                        switch (Input)
                        {
                            case "0":
                                isQuest1 = false;
                                break;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
                        Console.WriteLine($"\n\n미니언 5마리 처치 ({/* 미니언 카운트 */}/5)"); // 미니언 카운트로 해서 몇마리 잡았는지 실시간으로 표시
                        Console.WriteLine("\n보상");
                        Console.WriteLine("(아이템) x1, 5G");
                        Console.WriteLine("1. 보상받기");
                        Console.WriteLine("2. 돌아가기");

                        Console.WriteLine("\n원하시는 행동을 입력해주세요. >>");
                        string? Input = Console.ReadLine();

                        switch (Input)
                        {
                            case "1":
                                Console.WriteLine("퀘스트 보상을 받았습니다.");
                                character.Gold += 5; // 캐릭터의 골드 +5
                                QuestAccepted1 = false; // 퀘스트를 안받은 상태로 변경
                                isQuest1 = false;
                                break;
                            case "2":
                                isQuest1 = false;
                                break;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }
                    }
                }
                
            }
        }
<<<<<<< Updated upstream
=======

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
>>>>>>> Stashed changes
    }
}
