﻿using System;
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
        Warrior = 1, // 전사
        Wizard,      // 마법사
        Archer       // 궁수
    }

    public class Character
    {
        private List<Skill> skills;

        public const double MaxHealth = 100;     

        public GameClassType GameClass { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        public double BaseAttackPower { get; private set; }
        public double TotalAttackPower { get; private set; }
        public double BaseDefensePower { get; private set; }
        public double TotalDefensePower { get; private set; }
        public double CurrentHealth { get; private set; }
        public double MaxMana { get; private set; }
        public double CurrentMana { get; private set; }
        public int Experience { get; private set; }
        public int Gold { get; private set; }
        public bool IsDie { get; private set; }


        public Character(GameClassType gameClass, string name)
        {
            GameClass = gameClass;
            Name = name;

            Level = 1;
            CurrentHealth = 100;
            Gold = 1500;

            skills = new List<Skill>();
            switch (gameClass)
            {
                case GameClassType.Warrior:
                    BaseAttackPower = 10;
                    BaseDefensePower = 5;
                    MaxMana = 50;
                    CurrentMana = 50;

                    AddSkill(new Skill("알파 스트라이크", 10, 2f, 1));
                    AddSkill(new Skill("더블 스트라이크", 15, 1.5f, 2));
                    break;
                case GameClassType.Wizard:
                    BaseAttackPower = 15;
                    BaseDefensePower = 1;
                    MaxMana = 150;
                    CurrentMana = 150;

                    AddSkill(new Skill("크리스탈 블레이드", 60, 5f, 1));
                    AddSkill(new Skill("파이어 스톰", 30, 3f, 2));
                    break;
                case GameClassType.Archer:
                    BaseAttackPower = 18;
                    BaseDefensePower = 3;
                    MaxMana = 100;
                    CurrentMana = 100;

                    AddSkill(new Skill("레드 스윙", 50, 3f, 2));
                    AddSkill(new Skill("바이올렛 샷", 30, 2f, 3));
                    break;
            }
        }

        // 스킬 추가
        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }

        // 캐릭터의 정보 출력
        public void PrintCharacterInfo() 
        {

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
        public void BasicAttack()
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

            // 치명타 계산 및 
            bool isCritical = random.NextDouble() < 0.15; // 15% 확률로 발생
            if(isCritical)
            {
                attackDamage *= 1.6; // 160% 데미지
            }

            // 적중 실패 확률
            bool isAttackMiss = random.NextDouble() < 0.10; // 10% 확률로 발생
            if(isAttackMiss)
            {

            }
            else // 적중 성공
            {
                // 적 체력 감소
            }
        }

        // 스킬 사용
        public void UseSkill()
        {
            for (int i = 0; i < skills.Count; i++)
            {
                Console.WriteLine($"{i + 1} {skills[i].Name} - MP {skills[i].MpCost}");
                if(skills[i].TargetCount <= 2)
                {
                    Console.WriteLine($"  공격력 * {skills[i].DamageMultiplier}로 {skills[i].TargetCount}명의 적을 랜덤으로 공격합니다.");
                    // 몬스터 리스트 가져와서 랜덤 공격
                }
                else
                {
                    Console.WriteLine($"  공격력 * {skills[i].DamageMultiplier}로 하나의 적을 공격합니다.");
                }
                
            }
        }
    }
}
