using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    public class SceneManager
    {
        //싱글톤 생성
        public static SceneManager Instance;

        public Scene _introScene;
        public Scene _startScene;
        public Scene _characterInfoScene;
        public Scene _inventoryScene;
        public Scene _equipmentScene;
        public Scene _potionScene;

        public SceneManager()
        {
            if (Instance == null)
            {
                Instance = new SceneManager();
            }
            else
            {
                Instance = this;
            }

            _introScene = new IntroScene();
            _startScene = new StartScene();
            _characterInfoScene = new CharacterInfoScene();
            _inventoryScene = new InventoryScene();
            _equipmentScene = new EquipmentScene();
            _potionScene = new PotionScene();
        }
    }
}
