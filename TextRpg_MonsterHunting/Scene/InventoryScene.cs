using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting.Scene
{
    public class InventoryScene : Scene
    {
        //Game 인스턴스로 만들지 의논

        public override void loadScene(UI ui, Character character)
        {
            bool exitInventory = false;
            while (!exitInventory)
            {
                ui.PrintTitle("인벤토리 관리");

                character.inventory.ManageItems(); //인벤토리 목록 출력

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("0. 나가기\n");

                int userInput = ui.UserChoiceInput(0, 1);

                if (userInput == 0)
                {
                    exitInventory = true;
                }
                else
                {

                }
            }
        }
    }
}
