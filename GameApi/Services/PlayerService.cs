using GameApi.Models;
using MongoDB.Driver;

namespace GameApi.Services
{
    public class PlayerService : IPlayerService
    {
        private IMongoCollection<Player> _players;

        public PlayerService(IPlayerDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _players = database.GetCollection<Player>(settings.PlayersCollectionName);
        }
        public Player Create(Player player)
        {
            _players.InsertOne(player);
            return player;
        }

        public List<Player> Get()
        {
            return _players.Find(player => true).ToList();
        }

        public Player Get(string id)
        {
            return _players.Find(player => player.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _players.DeleteOne(player => player.Id.Equals(id));
        }

        public void Update(string id, Player player)
        {
            _players.ReplaceOne(player => player.Id.Equals(id), player);
        }
    }
}
