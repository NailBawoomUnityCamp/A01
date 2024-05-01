using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    internal class Dungeon
    {        //던젼 로직 작성
       


        //던젼 입장. 출력 할 문자열
        public void InDungeon()
        {       //
            Console.WriteLine($"\n\"{heroName}\"은(는) 던전에 입장했습니다.");
            Console.WriteLine("준비된 3마리의 몬스터 중");
            Console.WriteLine("한 마리가 생성됩니다.");
        }

        //파이트 씬 시작. 
        public void FightChoice()
        {
            // 사용자가 몬스터를 
            
            Console.WriteLine($"\n{heroName}은(는) {Monster}를 발견했다!."); //{Monster}에 발견한 몬스터 랜덤으로 입력 가능할까?
            Console.WriteLine($"{heroName}은(는) 이제 싸워야합니다!.\n");

            /* 사용자의 선택을 요구하는 코드를 작성
            1.싸운다 2.도망친다 선택*/
            Console.WriteLine("1. 싸운다");
            Console.WriteLine("2. 도망친다");
            string userInput = Console.ReadLine();

            // 선택에 따라 행동 수행
            switch (userInput)
            {
                case "1":
                    BattleStart();
                    break;
                case "2":
                    RunAway();
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 숫자 \'1과 2중에\' 선택하세요.");
                    break;
            }
        }

        // 전투 시작
        private void BattleStart()
        {
            // 전투를 시작하는 코드를 작성
            Console.WriteLine("전투를 시작합니다.");
        }

        // 도망가는 행동
        private void RunAway()
        {
            // 도망가는 행동을 처리하는 코드를 작성
            Console.WriteLine($"{heroName}은(는) 도망쳤습니다.");
        }
    }
}

