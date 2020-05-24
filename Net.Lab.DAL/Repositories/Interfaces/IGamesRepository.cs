using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DataContracts.Games;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetGames();

        Game GetGame(int id);

        void CreateGame(Game game);

        void EditGame(int id, Game game);

        void DeleteGame(int id);

        Task<IEnumerable<Game>> GetGamesAsync();

        Task<Game> GetGameAsync(int id);

        Task CreateGameAsync(Game game);

        Task EditGameAsync(int id, Game game);

        Task DeleteGameAsync(int id);
    }
}
