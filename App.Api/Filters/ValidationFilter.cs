using App.Api.Models;
using FluentValidation;
using System.Net;

namespace App.Api.Filters
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;
        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };
            var contextObj = context.Arguments.SingleOrDefault(x => x.GetType() == typeof(T)) as T;
            if (contextObj == null)
            {
                return Results.BadRequest(response);
            }
            var result = await _validator.ValidateAsync((T)contextObj);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    response.ErrorMessages.Add(error.ErrorMessage);
                }
                return Results.BadRequest(response);
            }
            return await next(context);

        }
    }


}
