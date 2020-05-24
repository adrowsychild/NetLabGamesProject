using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IAwardsRepository
    {
        IEnumerable<Award> GetAwards();

        Award GetAward(int id);

        void CreateAward(Award award);

        void EditAward(int id, Award award);

        void DeleteAward(int id);

        Task<IEnumerable<Award>> GetAwardsAsync();

        Task<Award> GetAwardAsync(int id);

        Task CreateAwardAsync(Award award);

        Task EditAwardAsync(int id, Award award);

        Task DeleteAwardAsync(int id);
    }
}
