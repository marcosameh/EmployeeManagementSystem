using App.Core.Entities;
using App.Core.Repository.IRepository;
using App.UI.Endpoints;
using App.UI.Models;
using App.UI.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Net;

public class EmployeeEndpointTests
{
    [Fact]
    public async Task CreateEmployee_Success()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();
        var mapperMock = new Mock<IMapper>();

        var employeeCreateDTO = new EmployeeCreateDTO { FirstName = "Marco", MiddleName= "Sameh", LastName = "Bokter" };
        var createdEmployee = new Employee { Id = 1, FirstName = "Marco", MiddleName = "Sameh", LastName = "Bokter" };

        mapperMock.Setup(m => m.Map<Employee>(employeeCreateDTO)).Returns(createdEmployee);

        var endpointResult = Results.Created($"/api/employee/{createdEmployee.Id}", new APIResponse { IsSuccess = true, StatusCode = HttpStatusCode.Created });

        employeeRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);
        employeeRepoMock.Setup(repo => repo.SaveAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await EmployeeEndpoint.CreateEmployee(employeeRepoMock.Object, mapperMock.Object, employeeCreateDTO);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.Created<APIResponse> createdResult)
        {
            var createdResponse = createdResult.Value;

          
            Assert.NotNull(createdResponse);
            Assert.Equal(HttpStatusCode.Created, createdResponse.StatusCode);
            Assert.True(createdResponse.IsSuccess);
            Assert.Equal($"/api/employee/{createdEmployee.Id}", createdResult.Location);
           
        }
        else
        {
         
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

    [Fact]
    public async Task GetAllEmployee_Success()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();

        var employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Mark",MiddleName="Kenneth", LastName = "Mardo" },
            new Employee { Id = 2, FirstName = "Marco", MiddleName="Sameh", LastName = "Boktor" }
        };

        employeeRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

        // Act
        var result = await EmployeeEndpoint.GetAllEmployee(employeeRepoMock.Object);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.Ok<APIResponse> okResult)
        {
            var response = okResult.Value;

            
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccess);
            Assert.Equal(employees, response.Result);
           
        }
        else
        {
           
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

    [Fact]
    public async Task GetEmployee_Exists_Success()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();

        var existingEmployee = new Employee { Id = 1, FirstName = "Mark", MiddleName = "Kenneth", LastName = "Mardo" };
        employeeRepoMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(existingEmployee);

        // Act
        var result = await EmployeeEndpoint.GetEmployee(employeeRepoMock.Object, 1);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.Ok<APIResponse> okResult)
        {
            var response = okResult.Value;

           
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccess);
            Assert.Equal(existingEmployee, response.Result);
          
        }
        else
        {
           
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

    [Fact]
    public async Task GetEmployee_NotExists_NotFound()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();

        employeeRepoMock.Setup(repo => repo.GetAsync(2)).ReturnsAsync((Employee)null);

        // Act
        var result = await EmployeeEndpoint.GetEmployee(employeeRepoMock.Object, 2);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.NotFound<APIResponse> notFoundResult)
        {
            var response = notFoundResult.Value;

          
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.False(response.IsSuccess);
            Assert.Contains("Employee with ID 2 not found.", response.ErrorMessages);
          
        }
        else
        {
           
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

    [Fact]
    public async Task UpdateEmployee_Success()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();
        var mapperMock = new Mock<IMapper>();

        var employeeUpdateDTO = new EmployeeUpdateDTO { Id = 1, FirstName = "Mark2", MiddleName = "Kenneth", LastName = "Mardo" };

        var existingEmployee = new Employee { Id = 1, FirstName = "Mark", MiddleName = "Kenneth", LastName = "Mardo" };
        employeeRepoMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(existingEmployee);

        var updatedEmployee = new Employee { Id = 1, FirstName = "Mark2", MiddleName = "Kenneth", LastName = "Mardo" };
        mapperMock.Setup(m => m.Map<Employee>(employeeUpdateDTO)).Returns(updatedEmployee);

        var endpointResult = Results.Ok(new APIResponse { IsSuccess = true, StatusCode = HttpStatusCode.OK });

        // Act
        var result = await EmployeeEndpoint.UpdateEmployee(employeeRepoMock.Object, mapperMock.Object, employeeUpdateDTO);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.Ok<APIResponse> okResult)
        {
            var response = okResult.Value;

       
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccess);
            
            
        }
        else
        {
        
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

    [Fact]
    public async Task DeleteEmployee_Success()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();

        var existingEmployee = new Employee { Id = 1, FirstName = "Mark", MiddleName = "Kenneth", LastName = "Mardo" };
        employeeRepoMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(existingEmployee);

        var endpointResult = Results.Ok(new APIResponse { IsSuccess = true, StatusCode = HttpStatusCode.NoContent });

        // Act
        var result = await EmployeeEndpoint.DeleteEmployee(employeeRepoMock.Object, 1);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.Ok<APIResponse> okResult)
        {
            var response = okResult.Value;

          
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.True(response.IsSuccess);
            
        }
        else
        {
            
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

    [Fact]
    public async Task DeleteEmployee_InvalidId_BadRequest()
    {
        // Arrange
        var employeeRepoMock = new Mock<IEmployeeRepository>();

        employeeRepoMock.Setup(repo => repo.GetAsync(2)).ReturnsAsync((Employee)null);

        var endpointResult = Results.BadRequest(new APIResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest });

        // Act
        var result = await EmployeeEndpoint.DeleteEmployee(employeeRepoMock.Object, 2);

        // Assert
        if (result is Microsoft.AspNetCore.Http.HttpResults.BadRequest<APIResponse> badRequestResult)
        {
            var response = badRequestResult.Value;

           
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(response.IsSuccess);
            Assert.Contains("Invalid Id", response.ErrorMessages);

        }
        else
        {
            Assert.True(false, $"Unexpected result type: {result.GetType().FullName}");
        }
    }

}
