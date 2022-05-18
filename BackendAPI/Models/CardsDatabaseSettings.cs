namespace BackendAPI.Models
{
    public class CardsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string[] CollectionName { get; set; } = null!;
    }
}
