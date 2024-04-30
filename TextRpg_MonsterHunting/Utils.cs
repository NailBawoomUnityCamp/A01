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
		//아이템 ID 생성기
		static int _itemid = 0;
	}


	public class ItemList
	{
		[JsonInclude]
		public List<EquipmentItem> Data { get; set; }

		[JsonConstructor]
		public ItemList(List<EquipmentItem> data)
		{
			this.Data = data;
		}
	}
}
