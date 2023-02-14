using JobApplication.Infra.Contract;
using JobApplication.Infra.Domain;
using JobApplication.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext _context;

        public EmployeeRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            
            await _context.Employee.AddAsync(employee);

            return await _context.SaveChangesAsync();

        }

        public async Task<Employee> DeleteEmployee(long employeeID)
        {
            var result = _context.Employee.FirstOrDefault(x => x.Id == employeeID);

            _context.Employee.Remove(result);

            _context.SaveChanges();

            return result;

        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            try
            {
                var employee = _context.Employee.Include(e => e.Department).ToList();

                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employee?> GetEmployee(long employeID)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == employeID);

            return employee;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employee.Update(employee);

            return await _context.SaveChangesAsync();
        }
    }
}