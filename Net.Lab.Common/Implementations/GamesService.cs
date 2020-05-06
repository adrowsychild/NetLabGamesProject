using System;
using System.Collections.Generic;
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
    }
}
