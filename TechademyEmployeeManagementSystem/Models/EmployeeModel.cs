using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagementSystem.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeEmail { get; set; }

        [Required]
        public string EmployeeGender { get; set; }

        [Required]
        public DateTime EmployeeDOB { get; set; }

        [Required]
        public string EmployeeContact { get; set; }

        [Required]
        public string EmployeeAddress { get; set; }

        [Required]
        public string EmployeeDesignation { get; set; }

        [Required]
        public string EmployeeImage { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        
    }
}
