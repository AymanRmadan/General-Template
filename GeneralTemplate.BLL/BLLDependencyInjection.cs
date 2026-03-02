
namespace GeneralTemplate.BLL
{
    public static class BLLDependencyInjection
    {

        public static IServiceCollection AddBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtProvider, JwtProvider>();


            services.AddAuthConfig(configuration);
            services.AddMapsterConfig();
            services.AddFluentValidationConfig();

            // To Handle Exceptions
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();


            return services;
        }




        private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.AddOptions<JwtOptions>()
                  .BindConfiguration("Jwt")
                  .ValidateDataAnnotations()
                  .ValidateOnStart();


            var jwtSetting = configuration.GetSection("Jwt").Get<JwtOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(o =>
               {
                   o.SaveToken = true;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidIssuer = jwtSetting?.Issuer,
                       ValidateAudience = true,
                       ValidAudience = jwtSetting?.Audience,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting?.Key!)),

                   };
               }
               );


            return services;
        }

        private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(config));
            return services;
        }

        private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                   .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }


}
