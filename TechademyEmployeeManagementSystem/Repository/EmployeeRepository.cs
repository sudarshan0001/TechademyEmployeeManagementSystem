using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Data;
using TechademyEmployeeManagementSystem.Models;

namespace TechademyEmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly appDbContext _dbContext;
        public EmployeeRepository(appDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable GetAllEmployees()
        {

            try
            {
                var emp = _dbContext.employee.ToList();
                return emp;
            }
            catch
            {
                return "Something went wrong while fetching Records";
            }
        }

        public EmployeeModel GetByEmployeeId(int Id)
        {
            var emp = _dbContext.employee.FirstOrDefault(t =>
               t.EmployeeId == Id);
            return emp;
        }

        public EmployeeModel GetByEmployeeName(string name)
        {
            var emp = _dbContext.employee.FirstOrDefault(t => t.EmployeeName == name);
            return emp;
        }

        public string AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO == null)
                {
                    return "NO Data Supplied";
                }

                CreatePasswordHash(employeeDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                EmployeeModel emp = new EmployeeModel();
                emp.EmployeeName = employeeDTO.EmployeeName;
                emp.EmployeeImage = employeeDTO.EmployeeImage;
                emp.EmployeeEmail = employeeDTO.EmployeeEmail;
                emp.EmployeeDOB = employeeDTO.EmployeeDOB;
                emp.EmployeeGender = employeeDTO.EmployeeGender;
                emp.EmployeeContact = employeeDTO.EmployeeContact;
                emp.EmployeeDesignation = employeeDTO.EmployeeDesignation;
                // emp.Password = employeeModel.Password;
                emp.EmployeeAddress = employeeDTO.EmployeeAddress;
                emp.PasswordHash = passwordHash;
                emp.PasswordSalt = passwordSalt;


                _dbContext.employee.Add(emp);
                _dbContext.SaveChanges();
                return "successfully Added New Employee";
            }
            catch
            {
                return "Something went wrong while Adding New Employee";
            }
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                var emp = _dbContext.employee.FirstOrDefault(t => t.EmployeeId == id);
                if (emp == null)
                {
                    return "Record Not Found";
                }

                _dbContext.employee.Remove(emp);
                _dbContext.SaveChanges();
                return "Record successfully deleted";
            }
            catch
            {
                return "error occurred while accessing database or an object of data";
            }
        }

        public string UpdateEmployee(EmployeeModel employeeModel, int id)
        {
            try
            {
                if (employeeModel == null || employeeModel.EmployeeId != id)
                {
                    return "No Data supplied to an Object OR No Id mentioned in the input";
                }

                var emp = _dbContext.employee.FirstOrDefault(t => t.EmployeeId == id);
                if (emp == null)
                {
                    return "Record Not Found";
                }
                emp.EmployeeName = employeeModel.EmployeeName;
                emp.EmployeeImage = employeeModel.EmployeeImage;
                emp.EmployeeEmail = employeeModel.EmployeeEmail;
                emp.EmployeeDOB = employeeModel.EmployeeDOB;
                emp.EmployeeGender = employeeModel.EmployeeGender;
                emp.EmployeeContact = employeeModel.EmployeeContact;
                emp.EmployeeDesignation = employeeModel.EmployeeDesignation;
               // emp.Password = employeeModel.Password;
                emp.EmployeeAddress = employeeModel.EmployeeAddress;

                _dbContext.employee.Update(emp);
                _dbContext.SaveChanges();
                return "Record Successfully Updated";
            }
            catch
            {
                return "Something went wrong updating a record";
            }
        }


        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

       public string Login(LoginDTO loginDTO)
        {
            var user = _dbContext.employee.FirstOrDefault(t => t.EmployeeEmail == loginDTO.email);
            if(user == null)
            {
                return "user not found";
            }

            if (!VerifyPasswordHash(loginDTO.password, user.PasswordHash, user.PasswordSalt))
            {
                return "Wrong Password";
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer : "https://localhost:44378",
                audience : "https://localhost:44378",
                claims : new List<Claim>(),
                expires : DateTime.Now.AddDays(1),
                signingCredentials : signingCredentials
                );

            var TokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return TokenString ;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
