namespace GeneralTemplate.BLL
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
