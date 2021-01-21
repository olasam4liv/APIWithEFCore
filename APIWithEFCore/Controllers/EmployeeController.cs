using APIWithEFCore.EmployeeData;
using APIWithEFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWithEFCore.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/GetEmployees")]
        public IActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployees());
        }
        [HttpGet]
        [Route("api/GetEmployeeById/{Id}")]
        public IActionResult GetEmployeeById(Guid Id)
        {

            var employee = _employeeData.GetEmployeeById(Id);

            if (employee !=null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound($"Employee with the Id: {Id} was not found");
            }            
        }

        [HttpPost]
        [Route("api/AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);

            
        }

        [HttpDelete]
        [Route("api/DeleteEmployee/{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {

            var employee = _employeeData.GetEmployeeById(Id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok("Record Deleted");
            }
             
                return NotFound($"Employee with the Id: {Id} was not found");
            
        }
    }
}
