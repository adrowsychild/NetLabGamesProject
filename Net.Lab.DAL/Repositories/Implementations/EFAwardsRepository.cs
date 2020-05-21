using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class EFAwardsRepository : IAwardsRepository, IAwardsAsyncRepository
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

        public async Task<IEnumerable<Award>> GetAwardsAsync()
        {
            return await this.context.Awards.ToArrayAsync();
        }

        public async Task<Award> GetAwardAsync(int id)
        {
            return await this.context.Awards.FindAsync(id);
        }

        public async Task CreateAwardAsync(Award award)
        {
            await this.context.Awards.AddAsync(award);
            await this.context.SaveChangesAsync();
        }

        public async Task EditAwardAsync(int id, Award award)
        {
            var foundAward = await GetAwardAsync(id);
            foundAward = (Award)Net.Lab.DAL.Helpers.ModelsChangeHelper.AssignObject(foundAward, award);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAwardAsync(int id)
        {
            this.context.Awards.Remove(await GetAwardAsync(id));
            await this.context.SaveChangesAsync();
        }
    }
}
