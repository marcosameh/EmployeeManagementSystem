using App.UI.Models.DTO;
using FluentValidation;

namespace App.UI.Validations
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
