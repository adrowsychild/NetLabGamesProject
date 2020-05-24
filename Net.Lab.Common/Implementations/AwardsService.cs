using System;
using System.Collections.Generic;
using Net.Lab.Common.Interfaces;
using Net.Lab.DataContracts.Awards;
using Net.Lab.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Award>> GetAwardsAsync()
        {
            return await this.awardsRepository.GetAwardsAsync();
        }

        public async Task<Award> GetAwardAsync(int awardId)
        {
            return await this.awardsRepository.GetAwardAsync(awardId);
        }

        public async Task CreateAwardAsync(Award award)
        {
            await this.awardsRepository.CreateAwardAsync(award);
        }

        public async Task EditAwardAsync(int awardId, Award award)
        {
            await this.awardsRepository.EditAwardAsync(awardId, award);
        }

        public async Task DeleteAwardAsync(int awardId)
        {
            await this.awardsRepository.DeleteAwardAsync(awardId);
        }
    }
}
