using System;
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
        public void UseSkill(int skillIndex)
        {
            if (skillIndex >= 1 && skillIndex <= skills.Count)
            {
                Skill skillToUse = skills[skillIndex - 1];
                Console.WriteLine($"스킬 '{skillToUse.Name}'을(를) 사용했습니다.");
            }
            else
            {
                Console.WriteLine("잘못된 번호입니다.");
            }
        }
    }
}
