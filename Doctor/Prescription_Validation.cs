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
                .WithMessage("List of medicine is empty")
                .Must(BeValidMedicine)
                .WithMessage("Invalid signs in medicine")
                .MaximumLength(100)
                .WithMessage("Too much letters in medicine");

            RuleFor(p=>p.Dosage)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Dosage is empty")
                .Must(BeValidMedicine)
                .WithMessage("Invalid signs in dosage")
                .MaximumLength(100)
                .WithMessage("Too much letters in dosage");
        }

        private bool BeValidMedicine(string Medicine)
        {
            return Medicine.All(char.IsLetterOrDigit);
        }
    }
}
