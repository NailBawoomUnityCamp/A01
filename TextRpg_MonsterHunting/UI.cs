using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRpg_MonsterHunting
{
    public class UI
    {
        //행동 선택 리스트 출력
        public void PrintTitle(string topLineLetters, List<string> listOfChoices)
        {
            if (topLineLetters == "상태 보기")
            {
                Console.Clear();
                Console.WriteLine(topLineLetters);
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            }
            else if (topLineLetters == "전투 시작")
            {
                Console.Clear();
                Console.WriteLine(topLineLetters);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(topLineLetters);
            }

            int userChoice = 1;

            foreach (var item in listOfChoices)
            {
                if (item != "나가기")
                {
                    Console.WriteLine($"{userChoice}. {item}");
                    userChoice++;
                }
            }
            Console.WriteLine("\n0. 나가기");
        }

        //유저 선택 Input 받기
        public int UserChoiceInput(int userInput, List<string> listOfChoices)
        {
            Console.Write("\n원하시는 행동을 입력해 주세요.\n>> ");
            userInput = int.Parse(Console.ReadLine());

            while (userInput < 0 || userInput > listOfChoices.Count - 1)
            {
                Console.Write("잘못된 입력입니다. 다시 입력해 주세요. \n>> ");
                userInput = int.Parse(Console.ReadLine());
            }
            return userInput;
        }
    }
}
