
using App.Api.Models;
using System.Net;

namespace App.Api.Filters
{
    public class ParameterIDValidator : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var id = context.Arguments.SingleOrDefault(x => x?.GetType() == typeof(int)) as int?;
            if (id == null || id == 0 ||id <0)
            {
                APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };
                response.ErrorMessages.Add("Id cannot be zero or negative.");
                return Results.BadRequest(response);
            }
            return await next(context);
        }
    }
}
