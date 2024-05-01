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
        //행동 딕셔너리 생성
        Dictionary<string, string> titleTexts = new Dictionary<string, string>();

        //생성자를 통해 딕셔너리 초기화
        public UI()
        {
            //딕셔너리 초기화
            titleTexts.Add("상태 보기", "캐릭터의 정보가 표시됩니다.");
            titleTexts.Add("인벤토리 관리", "보유 중인 아이템을 관리할 수 있습니다.");
            titleTexts.Add("전투 시작", "전투가 시작되었습니다.");
        }

        //타이틀 출력
        //topLineLetters 값 변경
        //string topLineLetters = "";
        public void PrintTitle(string topLineLetters)
        {
            Console.Clear();
            //Console.WriteLine(topLineLetters);

            foreach (KeyValuePair<string, string> pair in titleTexts)
            {
                if(pair.Key == topLineLetters)
                {
                    Console.WriteLine(pair.Key);
                    Console.WriteLine(pair.Value);
                }
            }
        }

        //유저 선택 Input 받기
        public int UserChoiceInput(int start, int end)
        {
            Console.Write("\n원하시는 행동을 입력해 주세요.\n>> ");
            int userInput = int.Parse(Console.ReadLine());

            while (userInput < start || userInput > end)
            {
                Console.Write("잘못된 입력입니다. 다시 입력해 주세요. \n>> ");
                userInput = int.Parse(Console.ReadLine());
            }
            return userInput;
        }
    }
}
