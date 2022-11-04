using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;
using TechademyEmployeeManagementSystem.Repository;

namespace TechademyEmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("AllEmployee")]
        public IEnumerable GetAllEmployees()
        {
            var emp = _employeeRepository.GetAllEmployees();
            return emp;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public string AddEmployee([FromBody]EmployeeDTO employeeDTO)
        {
            var emp = _employeeRepository.AddEmployee(employeeDTO);
            return emp;
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _employeeRepository.DeleteEmployee(id);
            return Ok(emp);
        }

        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult Update([FromBody] EmployeeModel employeeModel, int id)
        {
            var emp = _employeeRepository.UpdateEmployee(employeeModel, id);
            return Ok(emp);
        }

        [HttpPost("Login")]
        public IActionResult login(LoginDTO loginDTO)
        {
            var response = _employeeRepository.Login(loginDTO);
            return Ok(new {Token = response });
        }
    }
}
