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

        /*메인 게임 루프
		 * 최초마을 화면
		 * 상태보기 기능을 선택하면 캐릭터의 스탯과 짐을 확인
		 * 전투 시작을 하면 몬스터와 전투를 시작
		*/
        //public void StartScreen(Character hero)
        //{
        //	bool leaveTown = false;
        //	while (!leaveTown)
        //	{
        //		//string topLineLetters =
        //		//("스파르타 던전에 오신 여러분 환영합니다.\n" +
        //		//"이제 전투를 시작할 수 있습니다.");
        //		string topLineLetters = "";


        //              //int userInput = 0; /*UI.함수이름(topLineLetters, listOfChoices)*/

        //              //_ui.PrintTitle(topLineLetters);
        //              //ui.UserChoiceInput(userInput, listOfChoices);

        //              _startScene.loadScene()

        //              //userInput = ui.UserChoiceInput(userInput, listOfChoices);

        //              switch (userInput)
        //		{
        //			case 0:
        //				leaveTown = true;
        //				break;
        //			case 1:
        //                      ui.PrintTitle(topLineLetters, listOfChoices);
        //                      hero.PrintCharacterInfo();
        //				break;
        //			case 2:
        //				//hero.Inventory.Manage();
        //				break;
        //		}
        //	}
        //}
    }
}
