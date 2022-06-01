using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Doctor
{
    public class Prescription_Validation: AbstractValidator<Prescription>
    {
        public Prescription_Validation()
        {
            RuleFor(p => p.Medicine)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Lista leków nie może być pusta")
                .Must(BeValidMedicine)
                .WithMessage("Lista leków zawiera niewłasciwe znaki")
                .MaximumLength(100)
                .WithMessage("Przekroczoną dostępną ilość znaków w liście leków");

            RuleFor(p=>p.Dosage)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Dawkowanie nie może być pusta")
                .Must(BeValidMedicine)
                .WithMessage("Dawkowanie zawiera niewłasciwe znaki")
                .MaximumLength(100)
                .WithMessage("Dawkowanie przekracza dostępną ilość znaków");
        }

        private bool BeValidMedicine(string Medicine)
        {
            return Medicine.All(char.IsLetterOrDigit);
        }
    }
}
