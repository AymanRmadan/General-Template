using GeneralTemplate.BLL.DTOS.Register.Requests;

namespace GeneralTemplate.BLL.Services.Abstractions.AuthServices
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellation = default);
        Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellation = default);
        Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellation = default);

        Task<Result> RegisterAsync(AddRegisterRequest request, CancellationToken cancellationToken = default);

        Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request);
        Task<Result> ResendConfirmationEmailAsync(AddResendConfirmationEmailRequest request);
    }

}
