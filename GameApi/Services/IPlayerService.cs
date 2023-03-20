using GameApi.Models;

namespace GameApi.Services
{
    public interface IPlayerService
    {
        List<Player> Get();
        Player Get(string id);
        Player Create(Player player);
        void Update(string id, Player player);
        void Remove(string id);
    }
}
