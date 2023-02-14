using Microsoft.AspNetCore.Http;

namespace JobApplication.Core.Domain.RequestModel
{
    public record EmployeeRequestModel
    {
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }   
        public IFormFile Photo { get; set; }
    }
}
