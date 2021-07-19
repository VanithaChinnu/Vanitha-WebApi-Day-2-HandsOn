using System.Collections.Generic;

namespace Vanitha_WebApi_Day_2_HandsOn.Models
{
    public class Department
    {
        public Department()
        {
            EMPLs = new HashSet<Employee>();
        }
        public int DId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> EMPLs { get; set; }
    }
}