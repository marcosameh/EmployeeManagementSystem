using App.UI.Models.DTO;
using FluentValidation;

namespace App.UI.Validations
{
    public class EmployeeUpdateValidation : AbstractValidator<EmployeeUpdateDTO>
    {
        public EmployeeUpdateValidation()
        {
                RuleFor(x=>x.Id).NotEmpty().GreaterThan(0);
                RuleFor(x=>x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
                RuleFor(x=>x.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
                RuleFor(x=>x.MiddleName).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
