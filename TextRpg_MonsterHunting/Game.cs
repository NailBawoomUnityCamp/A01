using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class Game
    {
        //우리의 주인공
        Character _hero;
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
                //싱글톤 사용하여 바로 불러오기
                SceneManager.Instance._introScene.loadScene(_ui, _hero); //이름, 직업 받은 후 마을로 이동
            }
        }
    }
}
