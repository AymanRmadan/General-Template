using GeneralTemplate.BLL.DTOS.Passwords.Requests;

namespace GeneralTemplate.BLL.DTOS.Passwords.Validations
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(r => r.CurrentPassword)
                .NotEmpty();

            RuleFor(r => r.NewPassword)
               .NotEmpty()
               .Matches(RegexPatterns.Password)
               .WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase")
               .NotEqual(r => r.CurrentPassword)
               .WithMessage("New Pass cannot be the same current pass");
        }
    }
}
