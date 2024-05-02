using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting.Scene
{
    public abstract class Scene
    {
        //List<string> listOfChoices;
        //public Scene()
        //{
        //    //listOfChoices = new List<string>();

        //    //listOfChoices.Add("나가기");
        //    //listOfChoices.Add("상태 보기");
        //    //listOfChoices.Add("인벤토리 관리");
        //    //listOfChoices.Add("전투 시작");
        //}

        public abstract void loadScene(UI ui, Character character);
    }
}
