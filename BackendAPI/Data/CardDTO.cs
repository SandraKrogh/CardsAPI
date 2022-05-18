using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendAPI.Data
{
    public class CardDTO
    {
		public string Class { get; set; }
		public string Type { get; set; }
		public string Set { get; set; }
		public int? SpellSchoolId { get; set; }
		public string Rarity { get; set; }
		public int? Health { get; set; }
		public int? Attack { get; set; }
		public int ManaCost { get; set; }

		public string artistName { get; set; }
		public string Text { get; set; }
		public string FlavorText { get; set; }
	}
}
