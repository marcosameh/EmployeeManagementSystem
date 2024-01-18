using App.UI.Models;
using App.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;
using System.Net;
using App.Core.Repository.IRepository;
using AutoMapper;
using App.Core.Entities;
using App.UI.Filters;

namespace App.UI.Endpoints
{
    public static class EmployeeEndpoint
    {
        public static void ConfigureEmployeeEndpoints(this WebApplication app)
        {

            app.MapGet("/api/employee", GetAllEmployee)
                .WithName("GetEmployees")
                .Produces<APIResponse>(200)
                .Produces(400);


            app.MapGet("/api/employee/{id:int}", GetEmployee)
                .WithName("GetEmployee").Produces<APIResponse>(200)
            .AddEndpointFilter<ParameterIDValidator>();

            app.MapPost("/api/employee", CreateEmployee)
                .WithName("CreateCoupon")
                .Accepts<EmployeeCreateDTO>("application/json")
                .Produces<APIResponse>(201)
                .Produces(400)
            .AddEndpointFilter<ValidationFilter<EmployeeCreateDTO>>();

            app.MapPut("/api/employee", UpdateEmployee)
                .WithName("UpdateCoupon")
                .Accepts<EmployeeUpdateDTO>("application/json")
                .Produces<APIResponse>(200).Produces(400)
            .AddEndpointFilter<ValidationFilter<EmployeeUpdateDTO>>();

            app.MapDelete("/api/employee/{id:int}", DeleteEmployee)
            .AddEndpointFilter<ParameterIDValidator>();
        }
        private static async Task<IResult> CreateEmployee(IEmployeeRepository employeeRepo, IMapper mapper,
                                                  [FromBody] EmployeeCreateDTO employeeCreateDTO)
        {
            var response = new APIResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            try
            {
                var employee = mapper.Map<Employee>(employeeCreateDTO);
                await employeeRepo.CreateAsync(employee);
                await employeeRepo.SaveAsync();
                response.Result = employee;
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.Created;
                return Results.Created($"/api/employee/{employee.Id}", employee);
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
                return Results.BadRequest(response);
            }
        }

        private static async Task<IResult> GetAllEmployee(IEmployeeRepository employeeRepo)
        {
            var response = new APIResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            try
            {
                var employees = await employeeRepo.GetAllAsync();

                if (employees != null)
                {
                    response.Result = employees;
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    return Results.Ok(response);
                }

                response.ErrorMessages.Add("No employees found.");
                response.StatusCode = HttpStatusCode.NotFound;
                return Results.NotFound(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
                return Results.BadRequest(response);
            }
        }

        private static async Task<IResult> GetEmployee(IEmployeeRepository employeeRepo, int id)
        {
            var response = new APIResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            try
            {
                var employee = await employeeRepo.GetAsync(id);

                if (employee != null)
                {
                    response.Result = employee;
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    return Results.Ok(response);
                }

                response.ErrorMessages.Add($"Employee with ID {id} not found.");
                response.StatusCode = HttpStatusCode.NotFound;
                return Results.NotFound(response);


            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
                return Results.BadRequest(response);
            }
        }
        private static async Task<IResult> UpdateEmployee(IEmployeeRepository employeeRepo, IMapper _mapper,
               [FromBody] EmployeeUpdateDTO employee_U_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            try
            {
                await employeeRepo.UpdateAsync(_mapper.Map<Employee>(employee_U_DTO));
                await employeeRepo.SaveAsync();
                response.Result = _mapper.Map<Employee>(await employeeRepo.GetAsync(employee_U_DTO.Id)); ;
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
                return Results.BadRequest(response);
            }

        }
        private static async Task<IResult> DeleteEmployee(IEmployeeRepository employeeRepo, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };


            Employee existingEmployee = await employeeRepo.GetAsync(id);
            if (existingEmployee != null)
            {
                try
                {
                    await employeeRepo.DeleteAsync(existingEmployee);
                    await employeeRepo.SaveAsync();
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.NoContent;
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    response.ErrorMessages.Add(ex.Message);
                    return Results.BadRequest(response);
                }

            }

            response.ErrorMessages.Add("Invalid Id");
            return Results.BadRequest(response);

        }

    }
}
