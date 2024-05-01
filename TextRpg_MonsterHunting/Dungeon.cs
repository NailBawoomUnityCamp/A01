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

        //파이트 초이스. 
        public void FightChoice()
        {
            // 사용자가 몬스터를 발견.
            Console.WriteLine($"\n{heroName}은(는) {monster}를 발견했다!."); /*1.game.cs에서 선언된 heroName은 어떻게 재활용 할 수있을까?
                                                                             2.발견한 monster의 이름을 어떻게 랜덤으로 입력 할 수 있을까?/*
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



        // 도망가는 행동을 처리하는 코드를 작성
        private void RunAway()
        {
            Console.WriteLine($"{heroName}은(는) 부리나케 도망쳤습니다."); // 도망가는 행동을 어떻게 작성해야 마을로 돌아가는지..
        }



        // 전투 시작
        private void BattleStart()
        {
            // 전투를 시작하는 코드를 작성
            Console.WriteLine("전투를 시작합니다.");

            // 박재우님께서 보강해주신 내용
            MonsterList();
            bool (isbattle) = true; // 전투 진행 여부 변수
            while (isbattle)
            {
                if (AllMonstersDead())//모든 몬스터가 죽었는지 확인
                {
                    Console.WriteLine("Victory! 모든 몬스터를 처치했습니다."); // 승리 메세지
                    isbattle = false; //전투 종료
                    continue;
                }

                if (character.CurrentHealth <= 0)
                {
                    Console.WriteLine("Lose... 플레이어가 쓰러졌습니다."); // 패배 메세지 출력
                    isbattle = false; //전투종료
                    continue
                }

                Console.WriteLine($"\n\n[내정보]"); // 내 정보 출력
                Console.WriteLine($"Lv.{character.Level} 이름(전사)"); // 캐릭터 레벨과 직업 출력
                Console.WriteLine($"Hp {character.CurrentHealth}/100"); // 현재 체력 출력
                Console.WriteLine("\n1. 공격"); //공격 옵션 출력
                Console.WriteLine("0. 취소"); //취소 옵션 출력

                Console.WriteLine("\n원하시는 행동을 입력해 주세요.") //사용자 입력 안내


                string? input = Console.ReadLine(); // 사용자 입력 받기

                switch (input) // 입력에 따른 처리
                {
                    case "1"; // 공격 선택시
                        Console.WriteLine("\n어떤 몬스터를 공격하시겠습니까? (1-4)"); // 공격할 몬스터 선택 안내
                        string? monsterInput = Console.ReadLine(); // 사용자가 선택한 몬스터
                        int selectedNumber;
                        if (int.TryParse(monsterInput, out selectedNumber) && selectedNumber >= 1 && selectedNumber <= selectedMonster.Count) // 유효한 입력 확인
                        {
                            monsterInput targetMonster = selectedMonsters[selectedNumber - 1]; // 선택한 몬스터

                            if (targetMonster.IsDead) // 이미 죽은 몬스터인지 확인
                            {
                                Console.WriteLine("이미 죽은 몬스터입니다."); // 이미 죽은 몬스터 안내
                            }
                            else
                            {
                                MonsterDamage();
                            }

                            EnemyPhase(character); // 적 턴으로 넘어가기
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다."); // 유효하지 않은 입력 안내
                        }
                        break;
                    case "9": // 몬스터 리롤 돌리기 위해서 넣어둠
                        isbattle = false; // 전투 종료
                        break;

                    case "0"; // 취소 선택 시
                        EnemyPhase(character); // 적 턴으로 넘어가기
                        break;

                    default; // 유효하지 않은 입력 시
                        Console.WriteLine("\n잘못된 입력입니다."); // 잘못된 입력 안내
                        break;
                }
            }
        }


        public void MonsterDamage()
        {

            if (BasicAttack > 0)
            {
                targetMonster.Health -= character.BasicAttack; // 몬스터에게 데미지 입히기
                Console.WriteLine($"[targetMonster.Name} 을(를) 맞췄습니다. (데미지 :{character.BasicAttack})"); // 몬스터에게 입힌 데미지 출력
                Console.WriteLine($"{targetMonster.Name} 의 남은 체력: {targetMonster.Health}"); // 몬스터의 남은 체력 출력

                if (targetMonster.Health <= 0)// 몬스터가 죽었는지 확인
                {
                    targetMonster.IsDead = true; // 몬스터 상태를 죽은 상태로 변경
                    Console.WriteLine($"{targetMOnster.Name} 이(가) 쓰러졌습니다!"); // 몬스터 사망 메시지 출력
                    UpdateCountKillMonsters(targetMonster); // 몬스터 처치 카운트 업데이트
                }
            }
            else
            {
                Console.WriteLine("공격이 빗나갔습니다!");
            }
        }

        // 적의 턴을 처리하는 메서드 //2024.04.30 박재우
        public void EnemyPhase()
        {
            Character character = new Character();
            Console.WriteLine("\n적의 공격이 시작됩니다."); // 적의 공격 시작 메시지 출력
            foreach (var monster in selectedMonsters)
            {
                if (monster.IsDead == false) // 몬스터가 살아 있다면
                {
                    Console.WriteLine($"{monster.Name}가 공격합니다! 공격력 : {monster.AttackPower}"); // 몬스터가 공격하는 메시지 출력
                    character.CurrentHealth -= monster.AttackPower; // 플레이어 체력 감소
                    if (character.CurrentHealth <= 0) // 플레이어가 죽었다면
                    {
                        Console.WriteLine("플레이어가 쓰러졌습니다!"); // 플레이어 죽음 메시지 출력
                        break; // 반복문 종료
                    }
                }
                if (monster.IsDead == true) // 몬스터가 이미 죽었다면
                {
                    Console.WriteLine($"{monster.Name}은(는) 쓰러진 상태입니다."); // 현재 플레이어 체력 출력
                }
            }
            Console.WriteLine($"플레이어의 현재 체력: {character.CurrentHealth}"); // 현재 플레이어 체력 출력
        }

        // 몬스터 처치 횟수를 업데이트하는 메서드 //2024.04.30 박재우
        public void UpdateCountKillMonsters(TextRpg_MonsterHunting monster)
        {
            if (monster.IsDead) // 몬스터가 죽었다면
            {
                if (defeatedMonsters.Containkey(monster.Name)) // 이미 해당 몬스터가 딕셔너리에 있는지 확인
                {
                    defeatedMOnsters[monster.Name]++; // 딕셔너리에 해당 몬스터 카운트 업데이트
                }
                else
                {
                    defeatedMonsters.Add(monster.Name, 1); // 딕셔너리에 해당 몬스터 추가 및 카운트 초기화
                }

            }
        }

        // 미니언 수를 계산하는 메서드 //2024.04.30 박재우
        public int MinionCount()
        {

            int minuonCount = 0; // 미니언 수 초기화
            if (defeatedMonsters.ContainsKey("LV.2 미니언")) // LV.2 미니언이 딕셔너리에 있는지 확인
            {
                MinionCount = defeatedMOnstersp["Lv.2 미니언"]; // 미니언 수 
            }
            Console.WriteLine("잡은 미니언 마릿수: " + MinionCount); // 미니언 수 출력
            return MinionCount(); // 미니언 수 반환
        }

        // 몬스터 리스트 / 랜덤새성
        Random random = new Random(); // 랜덤 객체 새성

        Monster[] monsters = { // 몬스터 배열 초기화
            new Monster("LV.2 미니언", 15, 5, 2), // LV.2 미니언 생성 / 적힌 순서대로 '이름, 체력, 공격력, 경험치'
            new Monster("Lv.5 대포미니언", 25, 8, 2), // LV.5 대포미니언 생성
            new Monster("Lv.3 공허충", 10, 9, 3) //Lv.3 공허충 생성
        };

        Console.WriteLine("\n전투가 시작되었습니다!"); // 전투 시작 메시지 출력

        selectedMonsters.Clear(); // 선택된 몬스터 리스트 생성

        for (int i = 0; i< 4; i++) //4마리의 몬스터 선택
        {
            int index = random.Next(monsters.Length); // 랜덤한 인덱스 선택
            Monster selectedMonster = new Monster(monsters[index].Name, monsters[indexer].Health, monsters[indexer].AttackPower, TextRpg_MonsterHunting[indexer].EnemyExp); // 선택된 몬스터 추가
            selectedMonsters.Add(selectedMonster); // 선택된 몬스터 리스트 추가
        }

        //모든 몬스터가 죽었는지 확인하는 메서드 //2024.04.30 박재우
        private bool AllMOnstersDead()
    {
        foreach (var monster in selectedMonsters)
        {
            if (!monster.IsDead) return false; // 단 하나라도 살아 있는 몬스터가 있다면 전투 계속 진행
        }
        return true; // 모든 몬스터가 죽었을 경우 true 반환
    } 
}


