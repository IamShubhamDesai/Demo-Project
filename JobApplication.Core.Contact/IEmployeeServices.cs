using JobApplication.Core.Domain.RequestModel;
using JobApplication.Core.Domain.ResponseModel;
using JobApplication.Infra.Domain.Entities;

namespace JobApplication.Core.Contact
{
    public interface IEmployeeServices
    {
        Task<int> AddEmployeeAsync(EmployeeRequestModel employee);
        Task<EmployeeResponseModel> GetEmployeeAsync(long employeeID);
        Task<Employee> DeleteEmployeeAsync(long EmployeeID);
        Task<List<EmployeeResponseModel>> GetAllEmployeeAsync();
        Task UpdateStudentAsyc(EmployeeRequestModel employee, int employeeID);
    }
}
