namespace BackendAPI.Models
{
    public class CardsDatabaseSettings
    {
        public string ConnectionString = "mongodb://localhost:27017";

        public string DatabaseName = "CardsAPI";

        public string CardCollectionName = "Card";

        public string CardTypeCollectionName = "CardType";

        public string ClassCollectionName = "Class";

        public string RarityCollectionName = "Rarity";

        public string SetCollectionName = "Set";
    }
}
