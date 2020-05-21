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
        private IAwardsAsyncRepository awardsAsyncRepository;

        public AwardsService(IAwardsRepository awardsRepository)
        {
            this.awardsRepository = awardsRepository;
        }

        public AwardsService(IAwardsAsyncRepository awardsAsyncRepository)
        {
            this.awardsAsyncRepository = awardsAsyncRepository;
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
            return await this.awardsAsyncRepository.GetAwardsAsync();
        }

        public async Task<Award> GetAwardAsync(int awardId)
        {
            return await this.awardsAsyncRepository.GetAwardAsync(awardId);
        }

        public async Task CreateAwardAsync(Award award)
        {
            await this.awardsAsyncRepository.CreateAwardAsync(award);
        }

        public async Task EditAwardAsync(int awardId, Award award)
        {
            await this.awardsAsyncRepository.EditAwardAsync(awardId, award);
        }

        public async Task DeleteAwardAsync(int awardId)
        {
            await this.awardsAsyncRepository.DeleteAwardAsync(awardId);
        }
    }
}
