using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vanitha_WebApi_Day_2_HandsOn.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ADM214DBContext dc = new ADM214DBContext();
        public void DeleteEmployee(int eid)
        {
            Employee emp2delete = GetEmployeeById(eid);
            dc.EMPLs.Remove(emp2delete);
            dc.SaveChanges();
        }
        public List<Employee> GetAllEmployees()
        {
            return dc.EMPLs.ToList();
        }
        public Employee GetEmployeeById(int eid)
        {
          
                Employee emp = (from e in dc.EMPLs where e.Id == eid select e).First();
                return emp;
        }
        public void InsertEmployee(Employee emp)
        {
            dc.EMPLs.Add(emp);
            dc.SaveChanges();
        }
        public void UpdateEmployee(int eid, Employee emp)
        {
            Employee emp2edit = GetEmployeeById(eid);
            emp2edit.Id = emp.Id;
            emp2edit.Name = emp2edit.Name;
            emp2edit.Salary = emp.Salary;
            emp2edit.Permanent = emp.Permanent;
            emp2edit.Skills = emp.Skills;
            dc.SaveChanges();
        }
    }

}
