using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.Common.Interfaces
{
    public interface IAwardsService
    {
        IEnumerable<Award> GetAwards();

        Award GetAward(int awardId);

        void CreateAward(Award award);

        void EditAward(int awardId, Award award);

        void DeleteAward(int awardId);

        Task<IEnumerable<Award>> GetAwardsAsync();

        Task<Award> GetAwardAsync(int awardId);

        Task CreateAwardAsync(Award award);

        Task EditAwardAsync(int awardId, Award award);

        Task DeleteAwardAsync(int awardId);
    }
}
