namespace GameApi.Models
{
    public class PlayerDatabaseSettings : IPlayerDatabaseSettings
    {
        public string PlayersCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
