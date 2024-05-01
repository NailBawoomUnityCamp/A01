using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting.Scene
{
    public class IntroScene
    {
        public void loadScene(UI ui, Character hero)
        {
            Console.Write("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 설정해주세요.\n>> ");
            string? heroName = Console.ReadLine();

            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수");

            Console.WriteLine("\n원하시는 직업을 선택하세요: \n>> ");

            //UI에 직업 선택 함수 결과
            int inputForClass = ui.UserChoiceInput(1, 3);

            GameClassType heroClass;
            switch (inputForClass)
            {       //명시적 형변환
                case (int)GameClassType.Warrior:
                    hero = new Warrior(heroName ?? "르탄이");
                    break;
                case (int)GameClassType.Wizard:
                    hero = new Wizard(heroName ?? "르탄이");
                    break;
                case (int)GameClassType.Archer:
                    hero = new Archer(heroName ?? "르탄이");
                    break;
            }
        }
    }
}
