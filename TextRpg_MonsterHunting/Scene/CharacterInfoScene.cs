using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting.Scene
{
    public class CharacterInfoScene : Scene
    {
        public override void loadScene(UI ui, Character character)
        {
            ui.PrintTitle("상태 보기");

            character.PrintCharacterInfo(); //캐릭터 정보 출력

            Console.WriteLine("\n0. 나가기\n");

            int userInput = ui.UserChoiceInput(0, 0);

            if (userInput == 0)
            {
                //StartScene 으로 돌아가기
            }
        }
    }
}
