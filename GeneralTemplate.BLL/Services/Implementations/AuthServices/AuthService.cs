
using System.Security.Cryptography;

namespace GeneralTemplate.BLL.Services.Implementations.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        private readonly int _refreshTokenExpiryDays = 14;
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
            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiresOn = refreshTokenExpiration
            });

            await _userManager.UpdateAsync(user);

            var response = new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn * 60, refreshToken, refreshTokenExpiration);

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


        public async Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellation = default)
        {
            var userId = _jwtProvider.ValidateToken(token);
            if (userId is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidJwtToken);

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

            /*  if (user.IsDisabled)
                  return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

              if (user.LockoutEnd > DateTime.UtcNow)
                  return Result.Failure<AuthResponse>(UserErrors.LockedUser);*/

            var userRefrshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);
            if (userRefrshToken is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidRefreshToken);

            userRefrshToken.RevokedOn = DateTime.UtcNow;


            // var (userRoles, userPermissions) = await GetUserRolesAndPermissions(user, cancellation);
            var (newToken, expireIn) = _jwtProvider.GenerateToken(user);//, userRoles, userPermissions);

            var newRefreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = newRefreshToken,
                ExpiresOn = refreshTokenExpiration,

            });
            await _userManager.UpdateAsync(user);

            var response = new AuthResponse(user.Id, user.Email, user.FirstName
                                 , user.LastName, newToken, expireIn * 60
                                 , newRefreshToken, refreshTokenExpiration);

            return Result.Success(response);
        }



        public async Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellation = default)
        {
            var userId = _jwtProvider.ValidateToken(token);
            if (userId is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidJwtToken);

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

            var userRefrshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);
            if (userRefrshToken is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidRefreshToken);

            userRefrshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);
            return Result.Success();
        }



        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

    }
}
