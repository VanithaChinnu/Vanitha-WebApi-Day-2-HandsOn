using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vanitha_WebApi_Day_2_HandsOn.Models;
using Vanitha_WebApi_Day_2_HandsOn.Filters;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.SecurityTokenService;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vanitha_WebApi_Day_2_HandsOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository empRep;
        public EmployeeController(IEmployeeRepository ier)
        {
            empRep = ier;
        }
        [CustomAuthFilter]
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Employee>> GetStandard()
        {
                return empRep.GetAllEmployees();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]

        public ActionResult<Employee> Get(int id)
        {
              try
              {
                      return Ok(empRep.GetEmployeeById(id));
              }
              catch
              {
                throw new  BadRequestException("Invalid Employee Id");
              }
        }
        [CustomAuthFilter]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public ActionResult<Employee> Post(Employee emp)
        {
            empRep.InsertEmployee(emp);
            return Created($"api/Employee/{emp.Id}", emp);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Put(int id, Employee emp)
        {
            empRep.UpdateEmployee(id, emp);
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Delete(int id)
        {
            empRep.DeleteEmployee(id);
            return Ok();
        }
    }
}