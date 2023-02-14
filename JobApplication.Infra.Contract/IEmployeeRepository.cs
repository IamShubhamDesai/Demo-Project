using Azure;
using JobApplication.Infra.Domain.Entities;
using JobApplication.Shared;

namespace JobApplication.Infra.Contract
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployee(Employee employee);
        //Task<PagedList<Employee>> GetEmployees(string searchTerm = null, int page = 1, int pageSize = 25);
        Task<Employee> GetEmployee(long employeeID);
        Task<Employee> DeleteEmployee(long employeeID);
        Task<List<Employee>> GetAllEmployee();
        Task<int> UpdateEmployee(Employee employee);
    }
}
