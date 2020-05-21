using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DataContracts.Games;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IGamesAsyncRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();

        Task<Game> GetGameAsync(int id);

        Task CreateGameAsync(Game game);

        Task EditGameAsync(int id, Game game);

        Task DeleteGameAsync(int id);
    }
}
