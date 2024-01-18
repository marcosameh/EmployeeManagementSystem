using App.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.UI.Filters
{
    
        public class BasicValidator<T> : IAsyncActionFilter where T : class
        {
            private readonly IValidator<T> _validator;

            public BasicValidator(IValidator<T> validator)
            {
                _validator = validator;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                var contextObj = context.ActionArguments.SingleOrDefault(x => x.Value?.GetType() == typeof(T)).Value;

                if (contextObj == null)
                {
                    context.Result = new BadRequestObjectResult(response);
                    return;
                }

                var result = await _validator.ValidateAsync((T)contextObj);

                if (!result.IsValid)
                {
                    response.ErrorMessages.Add(result.Errors.FirstOrDefault()?.ErrorMessage ?? "Validation failed");
                    context.Result = new BadRequestObjectResult(response);
                    return;
                }

                await next();
            }
        }
    
}
