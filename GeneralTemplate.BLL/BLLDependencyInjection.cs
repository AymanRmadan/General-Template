

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GeneralTemplate.BLL
{
    public static class BLLDependencyInjection
    {

        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            //  services.AddScoped(typeof(IService<>), typeof(GenericService<>));
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IJwtProvider, JwtProvider>();




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
                       // ValidIssuer = jwtSetting?.Issuer,
                       ValidateAudience = true,
                       // ValidAudience = jwtSetting?.Audience,
                       ValidateLifetime = true,
                       // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting?.Key!)),

                   };
               }
               );


            return services;
        }


    }

}
