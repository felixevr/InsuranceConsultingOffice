using FluentValidation;
using InsuranceConsultingOffice.Application.Dtos.Request;

namespace InsuranceConsultingOffice.Application.Validators
{
    public class InsuredValidator : AbstractValidator<InsuredRequestDto>
    {
        public InsuredValidator()
        {
            RuleFor(x => x.IdCard)
                .NotNull().WithMessage("El campo de cédula no puede ser nulo")
                .NotEmpty().WithMessage("El campo de cédula no puede estar vacío");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede estar vacío");

            RuleFor(x => x.Phone)
                .NotNull().WithMessage("El campo de Teléfono no puede ser nulo")
                .NotEmpty().WithMessage("El campo Teléfono no puede estar vacío");

            RuleFor(x => x.Age)
                .NotNull().WithMessage("El campo edad no puede ser nulo")
                .NotEmpty().WithMessage("El campo de edad no puede estar vacío")
                .GreaterThanOrEqualTo(0).WithMessage("La edad no puede ser negativa")
                .LessThanOrEqualTo(120).WithMessage("La edad no puede ser mayor a 120 años");
        }
    }
}
