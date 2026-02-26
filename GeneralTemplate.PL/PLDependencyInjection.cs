using GeneralTemplate.DAL.Database;
using GeneralTemplate.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace GeneralTemplate.PL
{
    public static class PLDependencyInjection
    {
        public static IServiceCollection AddPL(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthConfig(config);

            return services;
        }


        private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().
                 AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            return services;

        }
    }
}
