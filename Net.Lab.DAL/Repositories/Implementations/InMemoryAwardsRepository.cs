using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class InMemoryAwardsRepository : IAwardsRepository
    {
        private List<Award> repository;
        private readonly IGamesRepository gamesRepository;
        private int idCount = 4;

        public InMemoryAwardsRepository(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;

            if (repository == null)
                repository = new List<Award>()
                {
                    new Award() { Id = 1, Name = "Best Independent Game 2015", GameId = 1 }, 
                    new Award() { Id = 2, Name = "Best Role Playing Game 2015", GameId = 1 },
                    new Award() { Id = 3, Name = "PC Gamer Game of the Year Awards 2013", GameId = 2 }
                };
        }

        public Award GetAward(int id)
        {
            var result = repository.Find(x => x.Id == id);
            if (result == null)
                throw new AwardNotFoundException();

            return result;
        }

        public IEnumerable<Award> GetAwards()
        {
            if (repository.Count == 0)
                throw new AwardNotFoundException();

            return repository.ToArray();
        }

        public void CreateAward(Award award)
        {
            if (isInvalidAward(award))
                throw new InvalidAwardException(award);

            award.Id = idCount++;
            if (GameExists(award.GameId))
                repository.Add(award);
            else
                throw new InvalidAwardException(award);
        }

        private bool GameExists(int gameId)
        {
            try
            {
                gamesRepository.GetGame(gameId);
                return true;
            }
            catch (GameNotFoundException)
            {
                return false;
            }
        }

        private bool isInvalidAward(Award award)
        {
            if (award == null || !GameExists(award.GameId))
                return true;
            else
                return false;
        }

        public void EditAward(int id, Award award)
        {
            if (award.Id != id)
                throw new InvalidAwardException(award);
            // message: "Game object should contain the same Id as Id to put it at."

            if (isInvalidAward(award))
                throw new InvalidAwardException(award);

            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[i].Id == award.Id)
                {
                    repository[i] = award;
                    return;
                }
            }

            throw new AwardNotFoundException();
        }

        public void DeleteAward(int id)
        {
            var result = repository.Find(x => x.Id == id);
            if (result == null)
                throw new AwardNotFoundException();

            repository.Remove(result);
        }

        public Task<IEnumerable<Award>> GetAwardsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Award> GetAwardAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAwardAsync(Award award)
        {
            throw new NotImplementedException();
        }

        public Task EditAwardAsync(int id, Award award)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAwardAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
