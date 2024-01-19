using App.Data.Entities;
using App.Api.Models.DTO;
using AutoMapper;

namespace App.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeUpdateDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();      
        }
    }
}
