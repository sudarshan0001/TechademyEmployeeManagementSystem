using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagementSystem.Models
{
    public class DesignationModel
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        public string DesignationName { get; set; }

        [Required]
        public string RoleName { get; set; }
        
        [Required]
        public string DepartmentName { get; set; }
    }
}
