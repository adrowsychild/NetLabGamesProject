using Net.Lab.DataContracts.Awards;
using System;
using System.Collections.Generic;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IAwardsRepository
    {
        IEnumerable<Award> GetAwards();

        Award GetAward(int id);

        void CreateAward(Award award);

        void EditAward(int id, Award award);

        void DeleteAward(int id);
    }
}
