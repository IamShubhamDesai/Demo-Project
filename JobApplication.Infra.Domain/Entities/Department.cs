using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication.Infra.Domain.Entities
{
    public class Department
    {
        public Department(int id,String departmentName)
        {
            Id = id;
            DepartmentName= departmentName;
        }

        public Department() { }
        public int Id { get; set; }
        public string? DepartmentName { get; set; }

    }
}
