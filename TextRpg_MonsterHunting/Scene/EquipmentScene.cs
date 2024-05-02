using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    internal class EquipmentScene : Scene
    {
        public void loadScene(UI ui, Character character)
        {
            ui.PrintTitle("인벤토리 - 장착 관리");

            character.inventory.PrintManageEquipments(); //장착 관리 목록 출력

            Console.WriteLine("\n0. 나가기");

            int userInput = ui.UserChoiceInput(0, 0);
        }
    }
}
