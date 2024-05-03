﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class SkillManager
    {
        private SkillList skills;

        public SkillManager()
        {
            skills = new SkillList();
        }

        // 스킬 추가
        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }

        // 스킬 목록 출력
        public void PrintSkills()
        {
            for (int i = 0; i < skills.Count; i++)
            {
                Console.WriteLine($"{i + 1} {skills[i].Name} - MP {skills[i].MpCost}");
                if (skills[i].TargetCount >= 2) // 광역스킬
                {
                    Console.WriteLine($"  공격력 * {skills[i].DamageMultiplier}로 {skills[i].TargetCount}명의 적을 랜덤으로 공격합니다.");
                }
                else // 단일스킬
                {
                    Console.WriteLine($"  공격력 * {skills[i].DamageMultiplier}로 하나의 적을 공격합니다.");
                }
            }
        }

        // 번호에 해당하는 스킬 사용(1번은 0번 스킬)
        public void UseSkill(int skillIndex, List<Monster> monsters, Character character)
        {
            if (skillIndex >= 1 && skillIndex <= skills.Count)
            {
                Skill skillToUse = skills[skillIndex - 1];
                Console.WriteLine($"스킬 '{skillToUse.Name}'을(를) 사용했습니다.");

                // 해당 스킬이 공격하는 몬스터수만큼 랜덤값 발생
                int targetCount = skillToUse.TargetCount;
                // 스킬로 공격가능한 몬스터수보다 현재 몬스터수가 더 작은지 체크
                if(targetCount > monsters.Count)
                {
                    targetCount = monsters.Count;
                }
                // 몬스터 목록의 몬스터 중에서 랜덤으로 공격
                HashSet<int> generatedIndex = new HashSet<int>();

                for (int i = 0; i < targetCount; i++)
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = new Random().Next(monsters.Count);
                    } while (!generatedIndex.Add(randomIndex)); // 이미 생성된 값이면 다시 생성

                    // 랜덤 지정된 몬스터 공격( 공격력 * 배수 )
                    double attackDamage = character.TotalAttackPower * skillToUse.DamageMultiplier;
                    attackDamage = Math.Round(attackDamage);
                    Console.WriteLine($"{monsters[randomIndex].Name}에게 '{attackDamage}'데미지를 입혔습니다!");
                    monsters[randomIndex].ChangeHealth(-attackDamage);
                    // 마나 감소
                    character.ChangeMana(-skillToUse.MpCost);
                }
            }
            else
            {
                Console.WriteLine("잘못된 번호입니다.");
            }
        }
    }
}
