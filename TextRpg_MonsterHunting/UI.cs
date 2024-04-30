using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    internal class UI
    {
        //마을에서 할 수 있는 행동 목록 리스트 생성
        List<Action> townActionList = new List<Action>();

        //마을 진입 시 기본 멘트 출력
        public void PrintTownIntro()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
        }

        //TownActionList 목록 추가
        public void AddTownAction()
        {
            townActionList.Add(new Action("상태 보기"));
            townActionList.Add(new Action("전투 시작"));
        }

        //TownActionList 목록 출력
        public void PrintTownAction(int userInput)
        {
            int actionCount = 1;

            foreach (var item in townActionList)
            {
                string userAction = item.TownAction;
                Console.WriteLine($"{actionCount}. {userAction}");
                actionCount++;
            }

            Console.Write("\n원하시는 행동을 입력해 주세요.\n>> ");
            userInput = int.Parse(Console.ReadLine());

            while (userInput <= 0 || userInput > townActionList.Count)
            {
                Console.Write("잘못된 입력입니다. 다시 입력해 주세요. \n>> ");
                userInput = int.Parse(Console.ReadLine());
            }
        }

        //캐릭터 정보 출력
        public void PrintCharacterInfo(Character character)
        {
            int level = character.Level;
            string name = character.Name;
            double baseAttackPower = character.BaseAttackPower;
            double baseDefensePower = character.BaseDefensePower;
            double currentHealth = character.CurrentHealth;
            int gold = character.Gold;

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv.{level}");
            Console.WriteLine($"{name} ( 전사 )");
            Console.WriteLine($"공격력 : {baseAttackPower}");
            Console.WriteLine($"방어력 : {baseDefensePower}");
            Console.WriteLine($"체　력 : {currentHealth}");
            Console.WriteLine($"Gold : {gold} G");


        }
    }
    class Action
    {
        //필드, 프로퍼티
        private string _townAction;

        public string TownAction
        {
            get { return _townAction; }
            set { _townAction = value; }
        }

        //생성자
        public Action(string action)
        {
            _townAction = action;
        }
    }
}
