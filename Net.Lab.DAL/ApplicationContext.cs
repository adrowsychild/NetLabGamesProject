using System;
using Microsoft.EntityFrameworkCore;
using Net.Lab.DataContracts.Awards;
using Net.Lab.DataContracts.Games;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base()
        { }

        public ApplicationContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Game> Games { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\selfd\source\repos\Net.Lab\Net.Lab.DAL\NetLabDB.mdf;Integrated Security=True");
        }
    }
}
