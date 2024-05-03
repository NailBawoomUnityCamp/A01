using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class Game
    {
        IntroScene _introScene = new IntroScene();
        UI _ui = new UI(); //UI 객체화
        bool leaveTown = false; //게임 실행 상태


        public Game()
        {
        }

        //게임 시작 method
        public void Start()
        {
            while (!leaveTown)
            {
                //introScene 불러오기
                _introScene.loadScene(_ui); //이름, 직업 받은 후 마을로 이동
            }
        }
    }
}
