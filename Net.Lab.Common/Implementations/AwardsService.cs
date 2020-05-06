using System;
using System.Collections.Generic;
using System.Linq;
using Net.Lab.DAL.Exceptions;
using Net.Lab.Common.Interfaces;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.Common.Implementations
{
    public class AwardsService : IAwardsService
    {
        private IGamesService gamesService;

        public AwardsService(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IEnumerable<Award> GetAwards(int gameId)
        {
            var awards = gamesService.GetGame(gameId).Awards;
            if (awards == null)
            {
                throw new AwardNotFoundException();
            }

            return awards;
        }

        public Award GetAward(int gameId, int awardId)
        {
            var awards = gamesService.GetGame(gameId).Awards.Where(x => x.Id == awardId).ToArray();
            if (awards == null || awards.Count() == 0)
                throw new AwardNotFoundException();

            return awards[0];
        }

        public void CreateAward(int gameId, Award award)
        {
            if (isInvalidAward(award))
                throw new InvalidAwardException(award);

            var game = gamesService.GetGame(gameId);
            var awards = game.Awards;
            var awardsEdited = new Award[game.Awards.Length + 1];
            for (int i = 0; i < game.Awards.Length; i++)
                awardsEdited[i] = game.Awards[i];

            awardsEdited[awards.Length] = award;
            game.Awards = awardsEdited;
            gamesService.EditGame(gameId, game);
        }

        public void EditAward(int gameId, int awardId, Award award)
        {
            if (isInvalidAward(award, awardId))
                throw new InvalidAwardException(award);

            var game = gamesService.GetGame(gameId);
            var awards = game.Awards;
            var awardIndex = FindAwardIndex(awards, awardId);
            if (awardIndex == -1)
                throw new AwardNotFoundException();
            awards[awardIndex] = award;
            game.Awards = awards;
            gamesService.EditGame(gameId, game);
        }

        public void DeleteAward(int gameId, int awardId)
        {
            var game = gamesService.GetGame(gameId);
            var awards = game.Awards;
            var awardIndex = FindAwardIndex(awards, awardId);
            if (awardIndex == -1)
                throw new AwardNotFoundException();
            awards = RemoveAt(awards, awardIndex);
            game.Awards = awards;
            gamesService.EditGame(gameId, game);
        }

        public Award[] RemoveAt(Award[] awards, int index)
        {
            Award[] awardsEdited = new Award[awards.Length - 1];
            for (int i = 0; i < awardsEdited.Length; i++)
            {
                if (i < index)
                    awardsEdited[i] = awards[i];
                else
                    awardsEdited[i] = awards[i + 1];
            }

            return awardsEdited;
        }

        private int FindAwardIndex(Award[] awards, int awardId)
        {
            for (int i = 0; i < awards.Length; i++)
            {
                if (awards[i].Id == awardId)
                    return i;
            }

            return -1;
        }
        
        private bool isInvalidAward(Award award)
        {
            if (award == null)
                return true;
            else
                return false;
        }

        private bool isInvalidAward(Award award, int awardId)
        {
            if (award.Id != awardId)
                return true;

            return isInvalidAward(award);
        }
    }
}
