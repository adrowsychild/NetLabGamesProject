using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class EFGamesRepository : IGamesRepository
    {
        private readonly ApplicationContext context;

        public EFGamesRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Game> GetGames()
        {
            return this.context.Games.ToArray();
        }

        public Game GetGame(int id)
        {
            return this.context.Games.Find(id);
        }

        public void CreateGame(Game game)
        {
            this.context.Games.Add(game);
            this.context.SaveChanges();
        }
        public void EditGame(int id, Game game)
        {
            var foundGame = GetGame(id);
            foundGame = (Game)Net.Lab.DAL.Helpers.ModelsChangeHelper.AssignObject(foundGame, game);
            this.context.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            this.context.Games.Remove(GetGame(id));
            this.context.SaveChanges();
        }

        private Game AssignGame(Game to, Game from)
        {
            to.Name = from.Name;
            to.Author = from.Author;
            to.Description = from.Description;
            to.ReleaseYear = from.ReleaseYear;
            return to;
        }
    }
}
