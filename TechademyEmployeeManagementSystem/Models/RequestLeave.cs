using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagementSystem.Models
{
    public class RequestLeave
    {
        [Key]
        public int LeaveId { get; set; }

        [Required]
        public string LeaveType { get; set; }

        [Required]
        public string LeaveDays { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public string LeaveReason { get; set; }

        [Required]
        public string LeaveStatus { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        //[ForeignKey("EmployeeId")]
        //public EmployeeModel employeeModel { get; set; }

    }
}
