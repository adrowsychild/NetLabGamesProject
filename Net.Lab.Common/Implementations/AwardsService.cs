using System;
using System.Collections.Generic;
using System.Linq;
using Net.Lab.DAL.Exceptions;
using Net.Lab.Common.Interfaces;
using Net.Lab.DataContracts.Awards;
using Net.Lab.DAL.Repositories.Interfaces;

namespace Net.Lab.Common.Implementations
{
    public class AwardsService : IAwardsService
    {
        private IAwardsRepository awardsRepository;

        public AwardsService(IAwardsRepository awardsRepository)
        {
            this.awardsRepository = awardsRepository;
        }

        public IEnumerable<Award> GetAwards()
        {
            return this.awardsRepository.GetAwards();
        }

        public Award GetAward(int awardId)
        {
            return this.awardsRepository.GetAward(awardId);
        }

        public void CreateAward(Award award)
        {
            this.awardsRepository.CreateAward(award);
        }

        public void EditAward(int awardId, Award award)
        {
            this.awardsRepository.EditAward(awardId, award);
        }

        public void DeleteAward(int awardId)
        {
            this.awardsRepository.DeleteAward(awardId);
        }
    }
}
