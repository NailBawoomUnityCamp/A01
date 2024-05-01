using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting.Scene
{
    public class StartScene : Scene
    {
        public override void loadScene(UI ui, Character character)
        {
            bool exitStart = false;
            while (!exitStart)
            {
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리 관리");
                Console.WriteLine("3. 전투 시작");
                Console.WriteLine("\n0. 나가기");

                int userInput = ui.UserChoiceInput(0, 3);

                if (userInput == 0)
                {
                    exitStart = true;
                }
                else if (userInput == 1)
                {

                }
            }
        }
    }
}
