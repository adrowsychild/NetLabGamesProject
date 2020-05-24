using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Games;

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

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await this.context.Games.ToArrayAsync();
        }

        public async Task<Game> GetGameAsync(int id)
        {
            return await this.context.Games.FindAsync(id);
        }

        public async Task CreateGameAsync(Game game)
        {
            await this.context.Games.AddAsync(game);
            await this.context.SaveChangesAsync();
        }

        public async Task EditGameAsync(int id, Game game)
        {
            var foundGame = await GetGameAsync(id);
            foundGame = (Game)Net.Lab.DAL.Helpers.ModelsChangeHelper.AssignObject(foundGame, game);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            this.context.Games.Remove(await GetGameAsync(id));
            await this.context.SaveChangesAsync();
        }
    }
}
