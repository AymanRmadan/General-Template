namespace GeneralTemplate.BLL
{
    public class UpdateProfileRequestValidator : AbstractValidator<UpdateProfileRequest>
    {
        public UpdateProfileRequestValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("Please add a {PropertyName}")
                .Length(3, 100);

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Please add a {PropertyName}")
                .Length(3, 100);
        }
    }
}
