namespace GeneralTemplate.BLL
{
    public class AddResendConfirmationEmailRequestValidator : AbstractValidator<AddResendConfirmationEmailRequest>
    {
        public AddResendConfirmationEmailRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
