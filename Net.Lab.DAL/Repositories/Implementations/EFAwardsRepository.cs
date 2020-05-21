using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Awards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class EFAwardsRepository : IAwardsRepository
    {
        private readonly ApplicationContext context;

        public EFAwardsRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Award> GetAwards()
        {
            return this.context.Awards.ToArray();
        }

        public Award GetAward(int id)
        {
            return this.context.Awards.Find(id);
        }
        
        public void CreateAward(Award award)
        {
            this.context.Awards.Add(award);
            this.context.SaveChanges();
        }
        public void EditAward(int id, Award award)
        {
            var foundAward = GetAward(id);
            foundAward = (Award)Net.Lab.DAL.Helpers.ModelsChangeHelper.AssignObject(foundAward, award);
            this.context.SaveChanges();
        }

        public void DeleteAward(int id)
        {
            this.context.Awards.Remove(GetAward(id));
            this.context.SaveChanges();
        }
    }
}
