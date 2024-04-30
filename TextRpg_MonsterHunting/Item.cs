using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
	//아이템이 올리는 능력치 타입
	public enum ItemType
	{
		Health = 1,
		Attack,
		Defence,
		Mana
	}

	//아이템 장비 신체 부위 타입
	public enum EquipmentType
	{
		Body = 1,
		OneHand
	}

	//아이템 인터페이스
	public interface Item
	{
		public string Name { get; }
		public string Discription { get; }
		public void PrintData();
	}

	//장비 아이템 클래스
	public class Equipment : Item
	{
		public string Name { get; private set; }
		public EquipmentType EquipType { get; private set; }
		public int Stat { get; private set; }
		public string Discription { get; private set; }
		public ItemType ItemType { get; private set; }

		public bool Equipped { get; set; }

		//Json 저장용 생성자
		[JsonConstructor]
		public Equipment(string name, EquipmentType equipType, int stat, string discription,
			 ItemType itemType, bool equipped)
		{
			this.Name = name;
			this.EquipType = equipType;
			this.Stat = stat;
			this.Discription = discription;
			this.ItemType = itemType;
			this.Equipped = equipped;
		}

		public Equipment(string name, EquipmentType equipType, int stat, string discription,
			 ItemType itemType)
		{
			Name = name;
			EquipType = equipType;
			Stat = stat;
			Discription = discription;
			ItemType = itemType;
			Equipped = false;
		}

		//장비 아이템 정보 출력
		public void PrintData()
		{
			//if (equipped && isShop == false)
			//{
			//	Console.Write($"[E]{Name}\t|");
			//}
			//else
			//{
			//	Console.Write($"{Name}  \t|");
			//}
			//switch (itemType)
			//{
			//	case ITEMTYPE.DEFENCE:
			//		Console.Write($"방어력 +{stat} | {discription}");
			//		break;
			//	case ITEMTYPE.ATTACK:
			//		Console.Write($"공격력 +{stat} | {discription}");
			//		break;
			//	case ITEMTYPE.HEALTH:
			//		Console.Write($"체력회복 +{stat} | {discription}");
			//		break;
			//}
		}
	}

	public class Potion : Item
	{
		public string Name { get; private set; }
		public int Stat { get; private set; }
		public string Discription { get; private set; }
		public ItemType ItemType { get; private set; }
		public bool Equipped { get; set; }

		[JsonConstructor]
		public Potion(string name, int stat, string discription,
			 ItemType itemType, int id, bool equipped)
		{
			this.Name = name;
			this.Stat = stat;
			this.Discription = discription;
			this.ItemType = itemType;
			this.Equipped = equipped;
		}

		public Potion(string name, int stat, string discription,
			 ItemType itemType)
		{
			Name = name;
			Stat = stat;
			Discription = discription;
			ItemType = itemType;
			Equipped = false;
		}

		public void Use(Character hero)
		{
			switch (ItemType)
			{
				case ItemType.Health:
					hero.ChangeHealth(Stat);
					break;
				case ItemType.Attack:
					hero.ChangeAttack(Stat);
					break;
				case ItemType.Defence:
					hero.ChangeDefense(Stat);
					break;
				case ItemType.Mana:
					//마나 수정 필요
					break;
			}
		}

		public void PrintData()
		{
			//if (equipped && isShop == false)
			//{
			//	Console.Write($"[E]{Name}\t|");
			//}
			//else
			//{
			//	Console.Write($"{Name}  \t|");
			//}
			//switch (itemType)
			//{
			//	case ITEMTYPE.DEFENCE:
			//		Console.Write($"방어력 +{stat} | {discription}");
			//		break;
			//	case ITEMTYPE.ATTACK:
			//		Console.Write($"공격력 +{stat} | {discription}");
			//		break;
			//	case ITEMTYPE.HEALTH:
			//		Console.Write($"체력회복 +{stat} | {discription}");
			//		break;
			//}
		}
	}

}
