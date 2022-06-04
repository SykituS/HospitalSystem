using FluentValidation;
using System.Linq;

namespace Doctor
{
    public class Referral_Validation : AbstractValidator<Referrals>
    {
        public Referral_Validation()
        {
            RuleFor(r => r.Referral)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Skierowanie nie może być pusta")
                .Must(BeValidReferral)
                .WithMessage("Błędne skierowanie. Zawiera niedozwolone znaki (można używać tylko liter i cyfr")
                .MaximumLength(200)
                .WithMessage("Wprowadzona wartość jest za długa");
        }

        private bool BeValidReferral(string referral)
        {
            return referral.All(char.IsLetterOrDigit);
        }

    }
}
