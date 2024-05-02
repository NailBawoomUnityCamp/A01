using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class StartScene : Scene
    {
        public void loadScene(UI ui, Character character)
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리 관리");
            Console.WriteLine("3. 회복 아이템 사용");
            Console.WriteLine("4. 전투 시작");
            Console.WriteLine("\n0. 나가기");

            int userInput = ui.UserChoiceInput(0, 4);

            switch(userInput)
            {
                case 0: //게임 종료

                    //게임 저장 기능 구현되면 추가하기

                    ui.CountdownComment(2, "게임이 종료됩니다.");

                    Environment.Exit(0); //정상 종료 코드 0, 음수값이 들어가면 비정상 종료

                    break;
                case 1: //상태 보기
                    SceneManager.Instance._characterInfoScene.loadScene(ui, character);
                    break;
                case 2: //인벤토리 관리
                    SceneManager.Instance._inventoryScene.loadScene(ui, character);
                    break;
                case 3: //회복 아이템 사용
                    SceneManager.Instance._potionScene.loadScene(ui, character);
                    break;
                case 4: //전투 시작(던전 입장)
                    Dungeon dungeon = new Dungeon();
                    dungeon.InDungeon(character, ui);
                    break;
            }
        }
    }
}
