using App.Core.Entities;
using App.UI.Models.DTO;
using AutoMapper;

namespace App.UI
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
