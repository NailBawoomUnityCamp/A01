using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpg_MonsterHunting
{
	/*게임 동작에 필요한 기타 기능들
	 * enum , method, List<class>대체 함수 등
	*/
	internal class Utils
	{
		
	}

	//json 저장용 List<Item> 대체 클래스
	public class ItemList
	{
		[JsonInclude]
		public List<Item> Data { get; private set; }
		[JsonInclude]
		public int Count { get; private set; }

		//Json 저장용 constructor
		[JsonConstructor]
		public ItemList(List<Item> data, int count)
		{
			this.Data = data;
			this.Count = count;
		}

		public ItemList()
		{
			this.Data = new List<Item>();
			this.Count = 0;
		}

		//기존 List의 Add 메소드를 이 클래스에 맞게 변환
		public void Add(Item item)
		{
			Data.Add(item);
			Count++;
		}

		//기존 List의 Remove 메소드를 이 클래스에 맞게 변환
		public void Remove(Item item)
		{
			Data.Remove(item);
			Count--;
		}

		//기존 List의 Contains 메소드를 이 클래스에 맞게 변환
		public bool Contains(Item item)
		{
			return Data.Contains(item);
		}
	}

	//json 저장용 List<Equipment> 대체 클래스
	public class EquipmentList
	{
		[JsonInclude]
		public List<Equipment> Data { get; set; }
		[JsonInclude]
		public int Count { get; private set; }

		[JsonConstructor]
		public EquipmentList(List<Equipment> data, int count)
		{
			this.Data = data;
			this.Count = data.Count;
		}

		public EquipmentList()
		{
			this.Data = new List<Equipment>();
			this.Count = 0;
		}

		public void Add(Equipment item)
		{
			Data.Add(item);
			Count++;
		}

		public void Remove(Equipment item)
		{
			Data.Remove(item);
			Count--;
		}

		public bool Contains(Equipment item)
		{
			return Data.Contains(item);
		}
	}

	//json 저장용 List<Potion> 대체 클래스
	public class PotionList
	{
		[JsonInclude]
		public List<Potion> Data { get; set; }
		[JsonInclude]
		public int Count { get; private set; }

		[JsonConstructor]
		public PotionList(List<Potion> data, int count)
		{
			this.Data = data;
			this.Count = data.Count;
		}

		public PotionList()
		{
			this.Data = new List<Potion>();
			this.Count = 0;
		}

		public void Add(Potion item)
		{
			Data.Add(item);
			Count++;
		}

		public void Remove(Potion item)
		{
			Data.Remove(item);
			Count--;
		}

		public bool Contains(Potion item)
		{
			return Data.Contains(item);
		}
	}
}
