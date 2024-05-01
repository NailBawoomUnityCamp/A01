using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRpg_MonsterHunting
{
    public class Character
    {
        public static Character instance;
        public const double MaxHealth = 100;     

        public int Level { get; private set; }
        public string Name { get; private set; }
        public double BaseAttackPower { get; protected set; }
        public double TotalAttackPower { get; private set; }
        public double BaseDefensePower { get; protected set; }
        public double TotalDefensePower { get; private set; }
        public double CurrentHealth { get; private set; }
        public double MaxMana { get; protected set; }
        public double CurrentMana { get; protected set; }
        public int Experience { get; private set; }
        public int Gold { get; private set; }
        public bool IsDie { get; private set; }
        public Inventory inventory { get; private set; }

        protected SkillManager skillManager;
        

        public Character(string name)
        {
            if (instance == null)
                instance = this;

            Name = name;

            Level = 1;
            CurrentHealth = 100;
            Gold = 1500;

            skillManager = new SkillManager();
        }

        // 캐릭터의 정보 출력
        public void PrintCharacterInfo() 
        {
            Console.WriteLine($"Lv. {Level.ToString("N2")}");
            Console.WriteLine();
        }

        // 총 방어력 합산/감산
        public void ChangeDefense(double changeDefense)
        {
            TotalDefensePower = BaseDefensePower + changeDefense;
        }

        // 총 공격력 합산/감산
        public void ChangeAttack(double changeAttack)
        {
            TotalAttackPower = BaseAttackPower + changeAttack;
        }

        // 총 체력 합산/감산
        public void ChangeHealth(double changeHealth)
        {
            CurrentHealth += changeHealth;

            // 체력이 최대 체력을 넘어가는지 확인
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            // 체력이 0 이하로 내려가는지 확인
            else if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsDie = true;
            }
        }

        // 골드 증가/감소
        public void ChangeGold(int changeGold)
        {
            Gold += changeGold;
        }

        // 레벨 / 경험치 증가
        public void Leveling(int monsterLevel)
        {
            switch (Experience)
            {
                // 레벨업
                case 10:
                case 35:
                case 65:
                case 100:
                    Level += 1;
                    BaseAttackPower += 0.5;
                    BaseDefensePower += 1.0;
                    break;
                default:
                    // 경험치 증가
                    Experience += monsterLevel;
                    break;
            }
        }

        // 공격 기능, 피해량 반환
        public double BasicAttack()
        {
            // 공격력은 10%의 오차를 가짐
            double errorRange = TotalAttackPower * 0.1;
            errorRange = Math.Ceiling(errorRange); // 올림

            // 피해량 계산
            Random random = new Random();
            double min = TotalAttackPower - errorRange;
            double max = TotalAttackPower + errorRange;
            double attackDamage = min + random.NextDouble() * (max - min);

            // 치명타 계산 
            bool isCritical = random.NextDouble() < 0.15; // 15% 확률로 발생
            if(isCritical)
            {
                attackDamage *= 1.6; // 160% 데미지
            }

            // 적중 실패 확률
            bool isAttackMiss = random.NextDouble() < 0.10; // 10% 확률로 발생
            if(isAttackMiss)
            {
                return 0;
            }
            else // 적중 성공,적 체력 감소
            {               
                return attackDamage;
            }
        }
    }

    public class Warrior : Character
    {
        public Warrior(string name):base(name)
        {
            BaseAttackPower = 10;
            BaseDefensePower = 5;
            MaxMana = 50;
            CurrentMana = 50;

            // 스킬 추가
            skillManager.AddSkill(new Skill("알파 스트라이크", 10, 2f, 1));
            skillManager.AddSkill(new Skill("더블 스트라이크", 15, 1.5f, 2));
        }
    }
     
    public class Wizard : Character
    {
        public Wizard(string name) : base(name)
        {
            BaseAttackPower = 15;
            BaseDefensePower = 1;
            MaxMana = 150;
            CurrentMana = 150;

            skillManager.AddSkill(new Skill("크리스탈 블레이드", 60, 5f, 1));
            skillManager.AddSkill(new Skill("파이어 스톰", 30, 3f, 2));
        }
    }

    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            BaseAttackPower = 18;
            BaseDefensePower = 3;
            MaxMana = 100;
            CurrentMana = 100;

            skillManager.AddSkill(new Skill("레드 스윙", 50, 3f, 2));
            skillManager.AddSkill(new Skill("바이올렛 샷", 30, 2f, 3));
        }
    }
}
