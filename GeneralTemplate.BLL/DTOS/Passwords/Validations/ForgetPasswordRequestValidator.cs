using GeneralTemplate.BLL.DTOS.Passwords.Requests;

namespace GeneralTemplate.BLL.DTOS.Passwords.Validations
{
    public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
    {
        public ForgetPasswordRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();


        }
    }
}
