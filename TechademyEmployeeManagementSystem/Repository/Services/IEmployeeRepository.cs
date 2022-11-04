using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;

namespace TechademyEmployeeManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        public IEnumerable GetAllEmployees();
        public EmployeeModel GetByEmployeeId(int Id);
        public EmployeeModel GetByEmployeeName(string name);
        public string AddEmployee(EmployeeDTO employeeDTO);
        public string DeleteEmployee(int id);
        public string UpdateEmployee(EmployeeModel employeeModel, int id);
        public string Login(LoginDTO loginDTO);
    }
}
