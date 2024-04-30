using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRpg_MonsterHunting
{
    // 직업
    public enum GameClassType
    {
        Warrior = 1,
        Wizard,
        Archer
    }

    public class Character
    {
        public const double MaxHealth = 100;
        public GameClassType GameClass { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        public double BaseAttackPower { get; private set; }
        public double TotalAttackPower { get; private set; }
        public double BaseDefensePower { get; private set; }
        public double TotalDefensePower { get; private set; }
        public double CurrentHealth { get; private set; }
        public int Experience { get; private set; }
        public int Gold { get; private set; }
        public bool IsDie { get; private set; }


        public Character(GameClassType gameClass, int level, string name, double baseAttackPower, double baseDefensePower, int gold)
        {
            GameClass = gameClass;
            Level = level;
            Name = name;
            BaseAttackPower = baseAttackPower;
            BaseDefensePower = baseDefensePower;
            TotalAttackPower = gold;

            CurrentHealth = 100;
        }

        // 캐릭터의 정보 출력
        public void PrintCharacterInfo() { }

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
                    Level = 2;
                    break;
                case 35:
                    Level = 3;
                    break;
                case 65:
                    Level = 4;
                    break;
                case 100:
                    Level = 5;
                    break;
                default:
                    // 경험치 증가
                    Experience += monsterLevel;
                    break;
            }
        }

        // 공격 기능, 피해량 반환
        public double Attack()
        {
            // 일치하는 몬스터를 선택하지 않음

            // 이미 죽은 몬스터 공격

            // 일치하는 몬스터 선택
            // 공격력은 10%의 오차를 가짐
            double errorRange = TotalAttackPower * 0.1;
            errorRange = Math.Ceiling(errorRange); // 올림

            // 피해량 계산
            Random random = new Random();
            double min = TotalAttackPower - errorRange;
            double max = TotalAttackPower + errorRange;
            double attackDamage = min + random.NextDouble() * (max - min);

            return attackDamage; // 피해량 반환
        }
    }
}
