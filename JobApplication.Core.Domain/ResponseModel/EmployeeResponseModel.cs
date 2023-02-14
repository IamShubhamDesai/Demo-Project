namespace JobApplication.Core.Domain.ResponseModel;

public record EmployeeResponseModel
{
    public int Id { get; set; }
    public string? EmployeeName { get; set; }
    public string? DepartmentName { get; set; }
}
