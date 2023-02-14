using AutoMapper;
using JobApplication.Core.Builder;
using JobApplication.Core.Contact;
using JobApplication.Core.Domain.RequestModel;
using JobApplication.Core.Domain.ResponseModel;
using JobApplication.Infra.Contract;
using JobApplication.Infra.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace JobApplication.Core.Service
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<int> AddEmployeeAsync(EmployeeRequestModel employeeModel)
        {
            try
            {
                var employee = EmployeeBuilder.Build(employeeModel);

                var fileName = employeeModel.Photo.FileName;

                var path = $"wwwroot/Photo/{fileName}";

                using (var FStream = System.IO.File.Create(path))
                {
                    var stream = employeeModel.Photo.OpenReadStream();
                    FStream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(FStream);

                }

                    var count = await _employeeRepository.AddEmployee(employee);

                if (count == 0)
                {
                    throw new BadRequestException("Employee is Not Created Succesfully.");
                }
                return count;
            }
            catch (Exception) 
            {
                throw;
            }
            
        }
        public async Task<EmployeeResponseModel> GetEmployeeAsync(long employeID)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployee(employeID);
                var result = _mapper.Map<EmployeeResponseModel>(employee);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Employee> DeleteEmployeeAsync(long EmployeeID)
        {
            try
            {
                var employee = await _employeeRepository.DeleteEmployee(EmployeeID);

                if(employee == null)
                {
                    throw new NotFoundException($"Employee wirh {EmployeeID} is Not Found");
                }
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<EmployeeResponseModel>> GetAllEmployeeAsync()
        {   
            try
            {
                var employees = await _employeeRepository.GetAllEmployee();
                var result = _mapper.Map<List<EmployeeResponseModel>>(employees);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateStudentAsyc(EmployeeRequestModel employee, int employeeID)
        {
            try
            {
                var employe = await _employeeRepository.GetEmployee(employeeID);
                if(employe == null)
                {
                    throw new NotFoundException($"Employee With {employeeID} is Not Found");
                }

                employe.Update(employee.EmployeeName, employee.DepartmentId);
                var count = await _employeeRepository.UpdateEmployee(employe);

                if(count == 0)
                {
                    throw new BadRequestException("Student is Not Updated Successfully.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}