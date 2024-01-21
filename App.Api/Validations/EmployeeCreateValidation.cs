using App.Api.Models.DTO;
using FluentValidation;

namespace App.Api.Validations
{
    public class EmployeeCreateValidation : AbstractValidator<EmployeeCreateDTO>
    {
        public EmployeeCreateValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.MiddleName).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
