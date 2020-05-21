using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IAwardsAsyncRepository
    {
        Task<IEnumerable<Award>> GetAwardsAsync();

        Task<Award> GetAwardAsync(int id);

        Task CreateAwardAsync(Award award);

        Task EditAwardAsync(int id, Award award);

        Task DeleteAwardAsync(int id);
    }
}
