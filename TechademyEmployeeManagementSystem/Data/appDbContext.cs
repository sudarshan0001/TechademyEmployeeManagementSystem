using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;

namespace TechademyEmployeeManagementSystem.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options):base(options)
        {

        }

        public DbSet<EmployeeModel> employee { get; set; }
        public DbSet<DesignationModel> designation { get; set; }
        public DbSet<RequestLeave> Leave { get; set; }
    }
}
