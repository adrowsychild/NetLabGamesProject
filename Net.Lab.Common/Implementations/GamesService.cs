using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Games;

namespace Net.Lab.Common.Implementations
{
    public class GamesService : IGamesService
    {
        private IGamesRepository gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        public Game GetGame(int id)
        {
            return this.gamesRepository.GetGame(id);
        }

        public IEnumerable<Game> GetGames()
        {
            return this.gamesRepository.GetGames();
        }

        public void CreateGame(Game game)
        {
            this.gamesRepository.CreateGame(game);
        }

        public void EditGame(int id, Game game)
        {
            this.gamesRepository.EditGame(id, game);
        }

        public void DeleteGame(int id)
        {
            this.gamesRepository.DeleteGame(id);
        }

        public async Task<Game> GetGameAsync(int id)
        {
            return await this.gamesRepository.GetGameAsync(id);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await this.gamesRepository.GetGamesAsync();
        }

        public async Task CreateGameAsync(Game game)
        {
            await this.gamesRepository.CreateGameAsync(game);
        }

        public async Task EditGameAsync(int id, Game game)
        {
            await this.gamesRepository.EditGameAsync(id, game);
        }

        public async Task DeleteGameAsync(int id)
        {
            await this.gamesRepository.DeleteGameAsync(id);
        }
    }
}
