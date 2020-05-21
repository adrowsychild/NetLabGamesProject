using Microsoft.Extensions.DependencyInjection;
using Net.Lab.Common.Implementations;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL;
using Net.Lab.DAL.Repositories.Implementations;
using Net.Lab.DAL.Repositories.Interfaces;
using System;

namespace Net.Lab.Common
{
    public static class NetLabCommonRegister
    {
        public static void RegisterCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IAwardsService, AwardsService>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IGamesRepository, EFGamesRepository>();
            services.AddScoped<IAwardsRepository, EFAwardsRepository>();
            services.AddScoped<IReviewsRepository, EFReviewsRepository>();
            services.AddDbContext<ApplicationContext>();
            //services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();
            //services.AddSingleton<IAwardsRepository, InMemoryAwardsRepository>();
            //services.AddSingleton<IReviewsRepository, InMemoryReviewsRepository>();
        }
    }
}
