namespace TextRpg_MonsterHunting
{
    // 몬스터를 나타내는 클래스 정의 /2024.04.30 박재우
    public class Monster
    {
        // 몬스터의 속성들 /2024.04.30 박재우
        public string Name { get; set; } // 몬스터 이름
        public float AttackPower { get; set; } // 몬스터의 공격력
        public double Health { get; set; } // 몬스터의 체력
        public bool IsDead { get; set; } // 몬스터가 죽었는지 여부를 나타내는 플래그
        public float EnemyExp { get; set; } // 몬스터를 처치했을 때 얻는 경험치

        // 몬스터 객체를 초기화하는 생성자
        public Monster(string name, double health, float attackPower, float enemyExp)
        {
            Name = name;
            AttackPower = attackPower;
            Health = health;
            IsDead = false; // 몬스터는 처음에는 죽지 않은 상태/////////////////////////2024.04.30 박재우
            EnemyExp = enemyExp;
        }
    }

    // 전투를 나타내는 클래스 정의 //2024.04.30 박재우
    public class MonsterFight
    {
        // 전투에 선택된 몬스터를 담을 리스트
        List<Monster> selectedMonsters = new List<Monster>();

        // 처치된 몬스터를 추적할 딕셔너리
        public Dictionary<string, int> defeatedMonsters = new Dictionary<string, int>();

        // 몬스터 정보를 출력하는 메서드
        private void PrintMonstersInfo(List<Monster> monsters)
        {
            Console.WriteLine("\n[몬스터 정보]"); // 몬스터 정보 헤더 출력
            for (int i = 0; i < monsters.Count; i++)
            {
                if (!monsters[i].IsDead) // 몬스터가 살아 있다면
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name}, 체력: {monsters[i].Health}"); // 몬스터 이름과 체력 출력
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name} Dead"); // 몬스터가 죽었다면 죽음 표시 출력
                }
            }
        }


        // 전투를 시작하는 메서드 //2024.04.30 박재우
        public void BattleStart(Character character)
        {

            Random random = new Random(); // 랜덤 객체 생성

            Monster[] monsters = { // 몬스터 배열 초기화
            new Monster("LV.2 미니언", 15, 5, 2), // LV.2 미니언 생성
            new Monster("Lv.5 대포미니언", 25, 8, 5), // Lv.5 대포미니언 생성
            new Monster("Lv.3 공허충", 10, 9, 3) // Lv.3 공허충 생성
            };

            Console.WriteLine("\n전투가 시작되었습니다!"); // 전투 시작 메시지 출력

            selectedMonsters.Clear(); // 선택된 몬스터 리스트 초기화

            for (int i = 0; i < 4; i++) // 4마리의 몬스터 선택
            {
                int index = random.Next(monsters.Length); // 랜덤한 인덱스 선택
                Monster selectedMonster = new Monster(monsters[index].Name, monsters[index].Health, monsters[index].AttackPower, monsters[index].EnemyExp); // 선택된 몬스터 추가
                selectedMonsters.Add(selectedMonster); // 선택된 몬스터 리스트에 추가
            }

            bool isbattle = true; // 전투 진행 여부 변수

            while (isbattle) // 전투 진행 중 //2024.04.30 박재우
            {
                PrintMonstersInfo(selectedMonsters); // 선택된 몬스터 정보 출력

                if (AllMonstersDead()) // 모든 몬스터가 죽었는지 확인
                {
                    Console.WriteLine("Victory! 모든 몬스터를 처치했습니다."); // 승리 메시지 출력
                    isbattle = false; // 전투 종료
                    continue;
                }

                if (character.CurrentHealth <= 0) // 플레이어 체력이 0 이하인지 확인
                {
                    Console.WriteLine("Lose... 플레이어가 쓰러졌습니다."); // 패배 메시지 출력
                    isbattle = false; // 전투 종료
                    continue;
                }

                Console.WriteLine($"\n\n[내정보]"); // 내 정보 출력
                Console.WriteLine($"Lv.{character.Level} 이름 (전사)"); // 캐릭터 레벨과 직업 출력
                Console.WriteLine($"Hp {character.CurrentHealth}/100"); // 현재 체력 출력
                Console.WriteLine("\n1. 공격"); // 공격 옵션 출력
                Console.WriteLine("0. 취소"); // 취소 옵션 출력

                Console.WriteLine("\n 원하시는 행동을 입력해 주세요."); // 사용자 입력 안내

                string? input = Console.ReadLine(); // 사용자 입력 받기

                switch (input) // 입력에 따른 처리
                {
                    case "1": // 공격 선택 시
                        Console.WriteLine("\n어떤 몬스터를 공격하시겠습니까? (1-4)"); // 공격할 몬스터 선택 안내
                        string? monsterInput = Console.ReadLine(); // 사용자가 선택한 몬스터
                        int selectedNumber;
                        if (int.TryParse(monsterInput, out selectedNumber) && selectedNumber >= 1 && selectedNumber <= selectedMonsters.Count) // 유효한 입력 확인
                        {
                            Monster targetMonster = selectedMonsters[selectedNumber - 1]; // 선택한 몬스터

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

                    case "0": // 취소 선택 시
                        EnemyPhase(character); // 적 턴으로 넘어가기
                        break;

                    default: // 유효하지 않은 입력 시
                        Console.WriteLine("\n잘못된 입력입니다."); // 잘못된 입력 안내
                        break;
                }
            }
        }

        public void MonsterDamage(Character character)
        {
            if (BasicAttack > 0)
            {
                targetMonster.Health -= character.BasicAttack; // 몬스터에게 데미지 입히기
                Console.WriteLine($"이름 의 공격!"); // 캐릭터 공격 메시지 출력
                Console.WriteLine($"{targetMonster.Name} 을(를) 맞췄습니다. (데미지 :{character.BasicAttack})"); // 몬스터에게 입힌 데미지 출력
                Console.WriteLine($"{targetMonster.Name} 의 남은 체력: {targetMonster.Health}"); // 몬스터의 남은 체력 출력

                if (targetMonster.Health <= 0) // 몬스터가 죽었는지 확인
                {
                    targetMonster.IsDead = true; // 몬스터 상태를 죽은 상태로 변경
                    Console.WriteLine($"{targetMonster.Name} 이(가) 쓰러졌습니다!"); // 몬스터 사망 메시지 출력
                    UpdateCountKillMonsters(targetMonster); // 몬스터 처치 카운트 업데이트
                }
            }
            else
            {
                Console.WriteLine("공격이 빗나갔습니다!");
            }
        }

        // 모든 몬스터가 죽었는지 확인하는 메서드 //2024.04.30 박재우
        private bool AllMonstersDead()
        {
            foreach (var monster in selectedMonsters)
            {
                if (!monster.IsDead) return false; // 하나라도 살아 있는 몬스터가 있다면 전투 계속 진행
            }
            return true; // 모든 몬스터가 죽었을 경우 true 반환
        }

        // 적의 턴을 처리하는 메서드 //2024.04.30 박재우
        public void EnemyPhase(Character character)
        {
            Console.WriteLine("\n적의 공격이 시작됩니다."); // 적의 공격 시작 메시지 출력
            foreach (var monster in selectedMonsters)
            {
                if (monster.IsDead == false) // 몬스터가 살아 있다면
                {
                    Console.WriteLine($"{monster.Name}가 공격합니다! 공격력: {monster.AttackPower}"); // 몬스터가 공격하는 메시지 출력
                    character.CurrentHealth -= monster.AttackPower; // 플레이어 체력 감소
                    if (character.CurrentHealth <= 0) // 플레이어가 죽었다면
                    {
                        Console.WriteLine("플레이어가 쓰러졌습니다!"); // 플레이어 죽음 메시지 출력
                        break; // 반복문 종료
                    }
                }

                if (monster.IsDead == true) // 몬스터가 이미 죽었다면
                {
                    Console.WriteLine($"{monster.Name}은(는) 쓰러진 상태입니다."); // 몬스터가 이미 죽었다는 메시지 출력
                }
            }
            Console.WriteLine($"플레이어의 현재 체력: {character.CurrentHealth}"); // 현재 플레이어 체력 출력
        }

        // 몬스터 처치 횟수를 업데이트하는 메서드 //2024.04.30 박재우
        public void UpdateCountKillMonsters(Monster monster)
        {
            if (monster.IsDead) // 몬스터가 죽었다면
            {
                if (defeatedMonsters.ContainsKey(monster.Name)) // 이미 해당 몬스터가 딕셔너리에 있는지 확인
                {
                    defeatedMonsters[monster.Name]++; // 딕셔너리에 해당 몬스터 카운트 업데이트
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
            int minionCount = 0; // 미니언 수 초기화
            if (defeatedMonsters.ContainsKey("LV.2 미니언")) // LV.2 미니언이 딕셔너리에 있는지 확인
            {
                minionCount = defeatedMonsters["LV.2 미니언"]; // 미니언 수 업데이트
            }
            Console.WriteLine("잡은 미니언 마릿수: " + minionCount); // 미니언 수 출력
            return minionCount; // 미니언 수 반환
        }
    }
}