using GeneralTemplate.DAL.Database;
using GeneralTemplate.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace GeneralTemplate.PL
{
    public static class PLDependencyInjection
    {
        public static IServiceCollection AddPL(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthConfig(config);
            services.AddSwaggerConfig();

            return services;
        }


        private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().
                 AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            return services;

        }

        private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {

            // Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "General Template API",
                    Version = "v1"
                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your JWT token (e.g., Bearer eyJhbGciOi...)."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
            });


            return services;
        }


    }
}
