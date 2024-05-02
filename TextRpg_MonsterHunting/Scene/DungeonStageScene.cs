using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class DungeonStageScene : Scene
    {
        public void loadScene(UI ui, Character character)
        {
            Console.WriteLine("던전에 입장하였습니다.");
            Console.WriteLine("스테이지를 선택해 주세요.\n>> ");

            ui.UserChoiceInput(1, 3);
        }
    }
}
