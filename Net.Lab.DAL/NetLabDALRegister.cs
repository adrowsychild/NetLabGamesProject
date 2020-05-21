using Microsoft.Extensions.DependencyInjection;

namespace Net.Lab.DAL
{
    public static class NetLabDALRegister
    {
        public static void RegisterDALServices(this IServiceCollection services)
        {
            /*
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IAwardsService, AwardsService>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();
            services.AddSingleton<IAwardsRepository, InMemoryAwardsRepository>();
            services.AddSingleton<IReviewsRepository, InMemoryReviewsRepository>();*/
        }
    }
}
