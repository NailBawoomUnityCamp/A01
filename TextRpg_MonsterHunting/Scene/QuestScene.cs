using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    internal class QuestScene : Scene
    {
        int userInput;
        List<Quest> QuestList = QuestManager.Instance.Quests;

        public void loadScene(UI ui, Character character)
        {
            ui.PrintTitle("퀘스트");

            for (int i = 0; i <= QuestList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {QuestList[i].Title}");
            }

            userInput = ui.UserChoiceInput(0, QuestList.Count + 1);

            SceneManager.Instance._questAcceptScene.loadScene(ui, character);
        }


    }
}
