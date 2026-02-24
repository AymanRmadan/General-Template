using GeneralTemplate.BLL.Services.Implementations.Tests;

namespace GeneralTemplate.BLL
{
    public static class BLLDependencyInjection
    {
        // public static IServiceCollection AddBLL(this IServiceCollection services)
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            //  services.AddScoped(typeof(IService<>), typeof(GenericService<>));
            services.AddScoped<ITestService, TestService>();
            return services;
        }
    }
}
