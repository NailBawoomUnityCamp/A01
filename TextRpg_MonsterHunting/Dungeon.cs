using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    internal class Dungeon
    {

        //던젼 입장. 출력 할 문자열
        public void InDungeon()
        {       //
            Console.WriteLine("\n\"{heroName}\"은(는) 던전에 입장했습니다.");
            Console.WriteLine("준비된 3마리의 몬스터 중");
            Console.WriteLine("한 마리가 생성됩니다.");
        }

        //파이트 씬 시작. 
        public void FightScene()
        {
            //사용자가 몬스터를 발견함
            Console.WriteLine("\n{heroName}은(는) {Monster}를 발견했다!.");
            Console.WriteLine("{hewName}은(는) 이제 싸워야합니다!.\n");

            //1.싸운다 2.도망친다 선택.

            /*사용자는 이후 몬스터와 싸운다.
             * void BattleStart()를 대입해 배틀을 시작한다.*/

        }

        public void ExitDungeon()
        {
            //사용자가 2.도망친다를 선택하면 마을로 돌아간다.
        }


    }
}
