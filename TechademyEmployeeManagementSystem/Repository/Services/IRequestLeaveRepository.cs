using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;

namespace TechademyEmployeeManagementSystem.Repository.Services
{
    public interface IRequestLeaveRepository
    {
        public List<RequestLeave> GetAllLeave();
        public List<RequestLeave> GetLeaveById(int id);
        public string RequestLeave(RequestLeave request);
        public string UpdateRequest(RequestLeave request, int id);

    }
}
