using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
	// 인벤토리 클래스
	class Inventory
	{
		// 장착템 목록
		[JsonInclude]
		public EquipmentList EquipmentsInBag { get; set; }

		// 포션 목록
		public PotionList PotionsInBag { get; set; }

		// 신체 부위별 장착 아이템
		public Equipment? Body { get; set; }
		public Equipment? RightHand { get; set; }

		//Json 저장용 초기화 메소드
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

		//인벤토리 창
		//장착아이템, 소모템 목록을 표시하고 장착관리나, 나가기로 이어짐
		public void ManageItems()
		{
			bool exitInventory = false;
			while (!exitInventory)
			{
				string topLineLetter = ("인벤토리" +
				"\n보유 중인 아이템을 관리할 수 있습니다.\n");
				
				string firstListTitle = ("[장착 아이템 목록]");
				EquipmentList equipmentList = EquipmentsInBag;

				string secondListTitle = ("[소모 아이템 목록]");
				PotionList potionList = PotionsInBag;
				
				List<string> choices = new List<string>();
				choices.Add("나가기");
				choices.Add("장착 관리");

				int input = 0;
				//UI로 출력 및 값 가져오기

				switch (input)
				{
					case 0:
						exitInventory = true;
						break;
					case 1:
						ManageEquipments();
						break;
				}
			}
		}

		//장착 관리 창
		public void ManageEquipments()
		{
			//bool exitManageEquipments = false;
			//while (!exitManageEquipments)
			//{
			//	string topLineLetter = ("인벤토리" +
			//	"\n보유 중인 아이템을 관리할 수 있습니다.\n");

			//	string firstListTitle = ("[장착 아이템 목록]");
			//	EquipmentList equipmentList = EquipmentsInBag;

			//	string secondListTitle = ("[소모 아이템 목록]");
			//	PotionList potionList = PotionsInBag;

			//	List<string> choices = new List<string>();
			//	choices.Add("나가기");
			//	choices.Add("장착 관리");

			//	int input = 0;
			//	//UI로 출력 및 값 가져오기

			//	switch (input)
			//{
			//	case 0:
			//		if (manageEquipments)
			//		{
			//			manageEquipments = false;
			//		}
			//		else
			//		{
			//			exitInventory = true;
			//		}
			//		break;
			//	default:
			//		if (!manageEquipments && input == 1) // 장착 관리창이 아닐 때 장착관리창으로 이동
			//		{
			//			manageEquipments = true;
			//		}
			//		else //장착 관리 동작
			//		{
			//			Equipment item = EquipmentsInBag[input - 1];
			//			if (item.Equipped)//장착된 아이템 해제
			//			{
			//				if (item.EquipType == EquipmentType.Body)
			//				{
			//					Body = null;
			//					item.Equipped = false;
			//				}
			//				else if (item.EquipType == EquipmentType.OneHand)
			//				{
			//					RightHand = null;
			//					item.Equipped = false;
			//				}
			//			}
			//			else // 아이템 장착
			//			{
			//				if (item.EquipType == EquipmentType.Body)
			//				{
			//					if (Body != null)
			//					{
			//						Body.Equipped = false;
			//						Body = null;
			//					}
			//					Body = item;
			//					item.Equipped = true;
			//				}
			//				else if (item.EquipType == EquipmentType.OneHand)
			//				{
			//					if (RightHand != null)
			//					{
			//						RightHand.Equipped = false;
			//						RightHand = null;
			//					}
			//					RightHand = item;
			//					item.Equipped = true;
			//				}
			//			}
			//		}
			//		break;
			//}
		} 

	}
}
