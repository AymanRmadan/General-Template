
namespace GeneralTemplate.BLL.DTOS.Authentications.Validations
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(r => r.Token).NotEmpty();
            RuleFor(r => r.RefreshToken).NotEmpty();


        }

    }
}