using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
	//아이템이 올리는 능력치 타입
	enum ItemType
	{
		HEALTH,
		ATTACK,
		DEFENCE,

	}

	//아이템 장비 신체 부위 타입
	enum EquipmentType
	{
		BODY,
		ONEHAND
	}

	public abstract class Item
	{
		public string Name { get; private set; }
		public int Id { get; private set; }
		public abstract void Use(Character hero);
		public abstract void PrintData(bool isShop);
	}



}
