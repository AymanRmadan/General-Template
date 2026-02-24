
using GeneralTemplate.DAL.Database;

namespace GeneralTemplate.DAL
{
    public static class DALDependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
