using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vanitha_WebApi_Day_2_HandsOn.Models
{
   public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int eid);
        void InsertEmployee(Employee emp);
        void UpdateEmployee(int eid, Employee emp);
        void DeleteEmployee(int eid);
    }
}
