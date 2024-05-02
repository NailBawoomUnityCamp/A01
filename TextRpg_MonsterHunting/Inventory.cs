using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
    // 인벤토리 클래스
    public class Inventory
    {
        // 장착템 목록
        [JsonInclude]
        public EquipmentList EquipmentsInBag { get; private set; }

        // 포션 목록
        public PotionList PotionsInBag { get; private set; }

        // 신체 부위별 장착 아이템
        public Equipment? Body { get; set; }
        public Equipment? RightHand { get; set; }

        //Json 불러오는용 초기화 메소드
        [JsonConstructor]
        public Inventory(EquipmentList EquipmentsInBag, PotionList PotionsInBag, Equipment? Body, Equipment? RightHand)
        {
            this.EquipmentsInBag = EquipmentsInBag;
            this.PotionsInBag = PotionsInBag;
            this.Body = Body;
            this.RightHand = RightHand;
        }

        //초기화
        public Inventory()
        {
            EquipmentsInBag = new EquipmentList();
            PotionsInBag = new PotionList();
        }

        //인벤토리에 아이템 추가
        public void Add(Item item)
        {
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;
                EquipmentsInBag.Add(equipment);
            }
            else if (item is Potion)
            {
                Potion potion = (Potion)item;
                PotionsInBag.Add(potion);
            }
        }

        //인벤토리에서 아이템 제거
        public void Remove(Item item)
        {
            if (item is Equipment)
            {
                //장착템의 경우 장착 되어있으면 장착 해제 후 제거
                Equipment equipment = (Equipment)item;
                if (equipment.Equipped)
                {
                    if (equipment.EquipType == EquipmentType.OneHand)
                    {
                        RightHand = null;
                    }
                    else if (equipment.EquipType == EquipmentType.Body)
                    {
                        Body = null;
                    }
                    equipment.Equipped = false;
                }
                EquipmentsInBag.Remove(equipment);
            }
            else if (item is Potion)
            {
                Potion potion = (Potion)item;
                PotionsInBag.Remove(potion);
            }
        }

        //장비 장착
        //해당 신체부위에 넣어주고, 해당 아이템의 equipped = true
        //이미 장착된 템이 있으면 교체
        public void EquipItem(Equipment item)
        {
            if (item.EquipType == EquipmentType.Body)
            {
                if (Body != null)
                {
                    UnEquipItem(Body);
                }
                Body = item;
                item.Equipped = true;
            }
            else if (item.EquipType == EquipmentType.OneHand)
            {
                if (RightHand != null)
                {
                    UnEquipItem(RightHand);
                }
                RightHand = item;
                item.Equipped = true;
            }
        }

        //장착 해제
        //해제된 아이템 반환
        public Equipment UnEquipItem(Equipment item)
        {
            if (item.EquipType == EquipmentType.Body)
            {
                Body = null;
                item.Equipped = false;
            }
            else if (item.EquipType == EquipmentType.OneHand)
            {
                RightHand = null;
                item.Equipped = false;
            }
            return item;
        }

        //인벤토리 창
        //장착아이템, 소모템 목록을 표시
        public void PrintItems() //ManageItems
        {
            Console.WriteLine("[장착 아이템 목록]");
            //EquipmentList equipmentList = EquipmentsInBag;
            foreach (var item in EquipmentsInBag.Data)
            {
                string name = item.Name;                      //이름
                //EquipmentType equipmentType = item.EquipType; //장비(방어구, 무기) 타입
                int stat = item.Stat;                         //스탯
                string discription = item.Discription;        //설명
                ItemType itemType = item.ItemType;            //아이템이 올려주는 능력치 타입
                bool equipped = item.Equipped;                //장착 상태

                if (equipped == false)
                {                    //({equipmentType})
                    Console.WriteLine($"- {name} | {itemType}+{stat} | {discription}");
                }
                else
                {
                    Console.WriteLine($"- [E]{name} | {itemType}+{stat} | {discription}");
                }
                Console.WriteLine();
            }
            /* PotionScene 생성 전 작업
            Console.WriteLine("[소모 아이템 목록]");
            //PotionList potionList = PotionsInBag;
            foreach (var item in PotionsInBag.Data)
            {
                string name = item.Name;
                int stat = item.Stat;
                string discription = item.Discription;
                ItemType itemType = item.ItemType;

                Console.WriteLine($"- {name} | {itemType}+{stat} | {discription}");
            } */
        }

        //장착 관리 창
        public void PrintManageEquipments() //ManageEquipments
        {
            Console.WriteLine("[장착 아이템 목록]");
            //EquipmentList equipmentList = EquipmentsInBag;
            foreach (var item in EquipmentsInBag.Data)
            {
                string name = item.Name;                      //이름
                //EquipmentType equipmentType = item.EquipType; //장비(방어구, 무기) 타입
                int stat = item.Stat;                         //스탯
                string discription = item.Discription;        //설명
                ItemType itemType = item.ItemType;            //아이템이 올려주는 능력치 타입
                bool equipped = item.Equipped;                //장착 상태

                for (int i = 1; i < EquipmentsInBag.Data.Count; i++)
                {
                    Console.Write($"- {i}. ");

                    if (equipped == false)
                    {                    //({equipmentType})
                        Console.WriteLine($"{name} | {itemType}+{stat} | {discription}");
                    }
                    else
                    {
                        Console.WriteLine($"[E]{name} | {itemType}+{stat} | {discription}");
                    }
                }
                Console.WriteLine();
            }
        }

        public void ManageEquipments(int userInput)
        {
            Equipment item = EquipmentsInBag[userInput - 1];

            if (item.Equipped)//장착된 아이템 해제
            {
                UnEquipItem(item);
            }
            else//새로운 아이템은 장착
            {
                EquipItem(item);
            }
        }


    }
}
