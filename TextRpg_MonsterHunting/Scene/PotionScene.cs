using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    internal class PotionScene : Scene
    {
        public void loadScene(UI ui, Character character)
        {
            int userInput;
            do
            {
                ui.PrintTitle("회복");

                character.inventory.PrintPotionItems();
                Console.WriteLine("\n0. 나가기");

                int itemChoice = character.inventory.PotionsInBag.Data.Count;
                userInput = ui.UserChoiceInput(0, itemChoice);
                

            } while (userInput != 0);

            SceneManager.Instance._startScene.loadScene(ui, character);






        }
    }
}
