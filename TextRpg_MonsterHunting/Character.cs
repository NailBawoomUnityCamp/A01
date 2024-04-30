using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class Character
    {
        public int Level { get; private set; }
        public string Name { get; private set; }
        public float BaseAttackPower { get; private set; }
        public float TotalAttackPower { get; private set; }
        public float BaseDefensePower { get; private set; }
        public float TotalDefensePower { get; private set; }
        public float BaseHealth { get; private set; }
        public float TotalHealth { get; private set; }
        public int Experience { get; private set; }
        public int Gold { get; private set; }


        public Character(int level, string name, float baseAttackPower, float baseDefensePower, float baseHealth, int gold)
        {
            Level = level;
            Name = name;
            BaseAttackPower = baseAttackPower;
            BaseDefensePower = baseDefensePower;
            BaseHealth = baseHealth;
            TotalAttackPower = gold;
        }

        // 캐릭터의 정보 출력
        public void PrintCharacterInfo() { }

        // 총 방어력 합산/감산
        public void ChangeDefense(float changeDefense)
        {
            TotalDefensePower = BaseDefensePower + changeDefense;
        }

        // 총 공격력 합산/감산
        public void ChangeAttack(float changeAttack)
        {
            TotalAttackPower = BaseAttackPower + changeAttack;
        }

        // 총 체력 합산/감산
        public void ChangeHealth(float changeHealth)
        {
            TotalHealth = BaseHealth + changeHealth;
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
                    Experience += monsterLevel;
                    break;
            }
        }
    }
}
