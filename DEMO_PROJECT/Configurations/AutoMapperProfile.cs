using AutoMapper;
using JobApplication.Core.Domain.ResponseModel;
using JobApplication.Infra.Domain.Entities;

namespace DEMO_PROJECT.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeResponseModel>().ForMember(e=>e.DepartmentName,ex=> ex.MapFrom(exa=>exa.Department.DepartmentName));
        }
    }
}
