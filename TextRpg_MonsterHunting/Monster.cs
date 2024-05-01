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
            IsDead = false; // 몬스터는 처음에는 죽지 않은 상태
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
    }
}