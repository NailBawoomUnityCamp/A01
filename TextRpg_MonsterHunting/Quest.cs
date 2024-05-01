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
        private bool QuestAccepted1 = false; // 퀘스트 수락 여부 체크

        public void QuestUI()
        {
            bool IsQuest = true;

            while (IsQuest)
            {
                Console.WriteLine("\n== 퀘스트 목록 ==");
                Console.WriteLine("\m1. 마을을 위협하는 미니언 처치");
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
                Console.WriteLine("\n== 마을을 위협하는 미니언 처치 ==");
                Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나? \n마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!");
                Console.WriteLine("\n\n미니언 5마리 처치 (0/5)");
                Console.WriteLine("\n보상");
                Console.WriteLine("(아이템) x1, 5G");
                Console.WriteLine("1. 수락");
                Console.WriteLine("2. 거절");

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
        }
    }
}
