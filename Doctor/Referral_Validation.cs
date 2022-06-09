using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Referral_Validation : AbstractValidator<Referrals>
    {
        public Referral_Validation()
        {
            RuleFor(r => r.Referral)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Referral is empty")
                .Must(BeValidReferral)
                .WithMessage("Invalid signs in referral")
                .MaximumLength(200)
                .WithMessage("Too much letters");
        }

        private bool BeValidReferral(string referral)
        {
            return referral.All(char.IsLetterOrDigit);
        }

    }
}
