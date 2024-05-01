using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class QuestInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RewardGold { get; set; }
        public string RewardItem { get; set; }

        public QuestInfo(int id, string title, int rewardGold, string rewardItem)
        {
            Id = id;
            Title = title;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
        }
    }

    public class QuestManager
    {
        private List<QuestInfo> quests;

        public QuestManager()
        {
            quests = new List<QuestInfo>()
        {
            new QuestInfo(1, "마을을 위협하는 미니언 처치", 5, "(아이템) x1"),
            
            // 여기에 더 많은 퀘스트를 추가할 수 있습니다.
        };
        }

        public QuestInfo GetQuestById(int id)
        {
            return quests.Find(quest => quest.Id == id);
        }

        // 필요에 따라 더 많은 메서드를 추가할 수 있습니다. 예) 모든 퀘스트 리스트 반환, 퀘스트 추가 등

        /* 퀘스트를 받지않았다면, Quest1S() 호출
         * string input < 여기서 값을 처리
         * 퀘스트 bool = true 
         * 일때 quest1R() 호출
         * 퀘스트 조건 bool = true 일때
         * Quest1C() 호출
         * characr.Gold += 5;
         * 
         * 
         * public void Num1Q()
         * {
         *      if (QuestOK = false) {
         *      quest.Quest1S()
         *      input
         *      swich
         *      case "1":
         *      QuestOK = true;
         *      }
         *      
         *      else
         *      {
         *          if (QuestClear = false)
         *          {
         *              quest.Quest1ing()
         *              input
         *              swich
         *              
         *          }
         *          
         *          else
         *          {
         *              quest.Quest1Clear()
         *              보상 획득 관련 코드
         *          }
         *      }
         * }
         * 
         */
    }
}
