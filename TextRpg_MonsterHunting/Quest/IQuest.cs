﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public interface IQuest
    {
        public void QuestContent();
        public void CheckQuestProgress();
    }
}
