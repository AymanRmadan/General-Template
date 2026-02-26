namespace GeneralTemplate.BLL.Services.Abstractions.AuthServices
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellation = default);
    }
}
