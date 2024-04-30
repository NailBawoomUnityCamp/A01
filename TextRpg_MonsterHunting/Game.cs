using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
	internal class Game
	{
		//우리의 주인공
		Character hero;
		public Game()
		{

		}

		/*게임 시작 method
		* 게임 시작을 알리고 주인공의 이름과 직업을 선택하게 함
		*/
		public void Start()
		{
			Console.Write("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 설정해주세요.");
			string? characterName = Console.ReadLine();

			/*
			 * 직업 출력 코드 필요
			 */

			Console.Write("주인공 직업을 선택하세요: ");
			//직업 입력받기

			//캐릭터 생성과 게임 시작
			hero = new Character(1, characterName ?? "홍길동", 10, 5, 100, 1500);
			StartScreen(hero);
		}

		/*메인 게임 루프
		 * 최초마을 화면
		 * 상태보기 기능을 선택하면 캐릭터의 스탯과 짐을 확인
		 * 전투 시작을 하면 몬스터와 전투를 시작
		*/
		public void StartScreen(Character hero)
		{
			bool leaveTown = false;
			while (!leaveTown)
			{
				string topLineLetters =
				("스파르타 던전에 오신 여러분 환영합니다.\n" +
				"이제 전투를 시작할 수 있습니다.");

				List<String> listOfChoices = new List<String>();
				listOfChoices.Add("상태 보기");
				listOfChoices.Add("전투 시작");

				int userInput = 0; /*UI.함수이름(topLineLetters, listOfChoices)*/

				switch (userInput)
				{
					case 1:
						//캐릭터 상태출력
						break;
					case 2:
						break;
				}
			}
		}
	}
}
