using System;
using System.Collections.Generic;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Awards;
using Net.Lab.DataContracts.Games;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class InMemoryGamesRepository : IGamesRepository
    {
        private List<Game> repository;
        private int idCount = 5;

        public InMemoryGamesRepository()
        {
            Random r = new Random();

            if (repository == null)
                repository = new List<Game>()
                {
                    new Game() { Id = 1, Name = "Undertale", Author = "Toby Fox", Description = "A story about a child who has gallen into the Underground to the world of monsters.",
                    ReleaseYear = 2015, Awards = new Award[] { new Award() { Id = 1, Name = "Best Independent Game 2015" }, new Award() { Id = 2, Name = "Best Role Playing Game 2015" } },
                    Reviews = new Review[] { new Review() { Id = 1, IsPositive = true, Author = "Hooked Gamers", Description = "It is an outstanding creation I highly encourage anyone to go out and buy this game." }, new Review() { Id = 2, IsPositive = true, Author = "Vandal", Description = "Undertale is a masterpiece. Fresh, fun and unique, and one of those games you should play if you think you love video games." } } },
                    new Game() { Id = 2, Name = "Dota 2", Author = "Valve", Description = "A popular free-to-play strategy multiplayer.",
                    ReleaseYear = 2013, Awards = new Award[] { new Award() { Id = 1, Name = "PC Gamer Game of the Year Awards 2013" } }, 
                    Reviews =  new Review[] { new Review() { Id = 1, IsPositive = true, Author = "3DJuegos", Description = "DOTA 2 it's amazing. One of the best MOBA around. It needs a lot of practice to be mastered, but if you play MOBAs, then it is for you." } } },
                    new Game() { Id = 3, Name = "Soma", Author = "Frictional Games", Description = "An exciting sci-fi horror on the oceanbed.",
                    ReleaseYear = 2015 },
                    new Game() { Id = 4, Name = "Layers of fear", Author = "Bloober Team SA", Description = "A beautiful psychodelic horror about a crazy painter's life.",
                    ReleaseYear = 2016 },
                };
        }

        public Game GetGame(int id)
        {
            var result = repository.Find(x => x.Id == id);
            if (result == null)
                throw new Exception("Unknown error");
                //throw new GameNotFoundException();

            return result;
        }

        public IEnumerable<Game> GetGames()
        {
            if (repository.Count == 0)
                throw new GameNotFoundException();

            return repository.ToArray();
        }

        public void CreateGame(Game game)
        {
            if (isInvalidGame(game))
                throw new InvalidGameException(game);
            game.Id = idCount++;
            repository.Add(game);
        }

        private bool isInvalidGame(Game game)
        {
            if (game == null)
                return true;
            else
                return false;
        }

        public void EditGame(int id, Game game)
        {
            if (game.Id != id)
                throw new InvalidGameException(game);
            // message: "Game object should contain the same Id as Id to put it at."

            if (isInvalidGame(game))
                throw new InvalidGameException(game);

            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[i].Id == id)
                {
                    repository[i] = game;
                    return;
                }
            }

            throw new GameNotFoundException();
        }

        public void DeleteGame(int id)
        {
            var result = repository.Find(x => x.Id == id);
            if (result == null)
                throw new GameNotFoundException();

            repository.RemoveAll(x => x.Id == id);
        }
    }
}
