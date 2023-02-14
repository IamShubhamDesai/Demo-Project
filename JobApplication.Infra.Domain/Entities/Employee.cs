namespace JobApplication.Infra.Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string? EmployeeName { get; private set; }
        public int DepartmentID { get; private set; }
        public virtual Department? Department { get; set; }
        public string Photo { get; set; }

        protected Employee()
        {

        }
        public Employee(string employeeName, int departmentId, string photo)
        {
            EmployeeName = employeeName;
            DepartmentID = departmentId;
            Photo = photo;
        }

        public Employee Update(string name , int departmentID)
        {
            EmployeeName = name;
            DepartmentID = departmentID;
            return this;
        }

        
    }    
}
