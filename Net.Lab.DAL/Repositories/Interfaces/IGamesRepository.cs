using System;
using System.Collections.Generic;
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
    }
}
