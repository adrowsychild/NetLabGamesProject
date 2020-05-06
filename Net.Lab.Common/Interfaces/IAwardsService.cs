using System;
using System.Collections.Generic;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.Common.Interfaces
{
    public interface IAwardsService
    {
        IEnumerable<Award> GetAwards(int gameId);

        Award GetAward(int gameId, int awardId);

        void CreateAward(int gameId, Award award);

        void EditAward(int gameId, int awardId, Award award);

        void DeleteAward(int gameId, int awardId);
    }
}
