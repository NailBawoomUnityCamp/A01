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
			string? heroName = Console.ReadLine();

			string topLineLetter = "원하시는 직업을 선택하세요: ";
			List<String> listOfChoices = new List<String>();
			listOfChoices.Add("전사");
			listOfChoices.Add("마법사");
			listOfChoices.Add("궁수");
			int inputForClass = 0; //UI에 직업 선택 함수 결과
			GameClassType heroClass;
			switch (inputForClass)
			{
				case 1:
					heroClass = GameClassType.Warrior;
					break;
				case 2:
					heroClass = GameClassType.Wizard;
					break;
				case 3:
					heroClass = GameClassType.Archer;
					break;
				default:
					heroClass = GameClassType.Warrior;
					break;
			}

			//캐릭터 생성과 게임 시작
			hero = new Character(heroClass, heroName ?? "홍길동");
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
				listOfChoices.Add("나가기");
				listOfChoices.Add("상태 보기");
				listOfChoices.Add("전투 시작");

				int userInput = 0; /*UI.함수이름(topLineLetters, listOfChoices)*/

				switch (userInput)
				{
					case 0:
						leaveTown = true;
						break;
					case 1:
						hero.PrintCharacterInfo();
						break;
					case 2:
						break;
				}
			}
		}
	}
}
