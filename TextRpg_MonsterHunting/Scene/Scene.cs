using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public interface Scene
    {
        public void loadScene(UI ui, Character character);
    }
}
