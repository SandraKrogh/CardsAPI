using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendAPI.Models
{
    public class Card
    {
		public int Id { get; set; }
		public int ClassId { get; set; }
		public int cardTypeId { get; set; }
		public int cardSetId { get; set; }
		public int? SpellSchoolId { get; set; }
		public int RarityId { get; set; }
		public int? Health { get; set; }
		public int? Attack { get; set; }
		public int ManaCost { get; set; }

		public string artistName { get; set; }
		public string Text { get; set; }
		public string FlavorText { get; set; }
	}
}
