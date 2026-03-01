using GeneralTemplate.BLL.DTOS.Logins.Request;

namespace SurveyBasket.Contracts.Validations
{
    public class AddLoginRequestValidator : AbstractValidator<AddLoginRequest>
    {
        public AddLoginRequestValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty();


        }

    }
}
