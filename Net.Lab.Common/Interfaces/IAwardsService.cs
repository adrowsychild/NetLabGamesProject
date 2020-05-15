using System;
using System.Collections.Generic;
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
    }
}
