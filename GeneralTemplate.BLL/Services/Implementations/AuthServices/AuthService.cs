
namespace GeneralTemplate.BLL.Services.Implementations.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }


        public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            if (await _userManager.FindByEmailAsync(email) is not { } user)
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);
            /*
                        if (user.IsDisabled)
                            return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

                        var result = await _signInManager.PasswordSignInAsync(user, password, false, true);*/

            // if (result.Succeeded)
            //{
            //  var (userRoles, userPermissions) = await GetUserRolesAndPermissions(user, cancellationToken);

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);//, userRoles, userPermissions);
            // var refreshToken = GenerateRefreshToken();
            // var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpirtDays);

            /* user.RefreshTokens.Add(new RefreshToken
             {
                 Token = refreshToken,
                 ExpiresOn = refreshTokenExpiration
             });
*/
            // await _userManager.UpdateAsync(user);

            var response = new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn * 60);//, refreshToken, refreshTokenExpiration);

            return Result.Success(response);
            //  }
            /*
                        var error = result.IsNotAllowed
                        ? UserErrors.EmailNotConfirmed
                        : result.IsLockedOut
                        ? UserErrors.LockedUser
                        : UserErrors.InvalidCredentials;*/

            // return Result.Failure<AuthResponse>(");
            //  return null;
            //  return Result.Failure<AuthResponse>(result.IsNotAllowed ? UserErrors.EmailNotConfirmed : UserErrors.InvalidCredentials);
        }

    }
}
