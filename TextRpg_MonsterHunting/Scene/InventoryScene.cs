using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class InventoryScene : Scene
    {
        public void loadScene(UI ui, Character character)
        {
            Console.Clear();
            ui.PrintTitle("인벤토리 관리");

            character.inventory.PrintItems(); //인벤토리 목록 출력

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");

            int userInput = ui.UserChoiceInput(0, 1);

            if(userInput == 1)
            {
                SceneManager.Instance._equipmentScene.loadScene(ui, character);
            }
            else
            {
                SceneManager.Instance._startScene.loadScene(ui,character);
            }
        }
    }
}
