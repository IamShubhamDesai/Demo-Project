using JobApplication.Core.Domain.RequestModel;
using JobApplication.Infra.Domain.Entities;

namespace JobApplication.Core.Builder
{
    public class EmployeeBuilder
    {
        public static Employee Build(EmployeeRequestModel model, string createdByUserID = "")
        {
            return new Employee(model.EmployeeName, model.DepartmentId , model.Photo.FileName);
        }
    }
}