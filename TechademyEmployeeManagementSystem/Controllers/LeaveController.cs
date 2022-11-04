using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;
using TechademyEmployeeManagementSystem.Repository.Services;

namespace TechademyEmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IRequestLeaveRepository _requestLeaveRepository;
        public LeaveController(IRequestLeaveRepository requestLeaveRepository)
        {
            _requestLeaveRepository = requestLeaveRepository;
        }

        [HttpGet("leave-pending")]
        public List<RequestLeave> GetAll()
        {
            return _requestLeaveRepository.GetAllLeave();
        }

        [HttpPost("Request-Leave")]
        public string LeaveRequest([FromBody]RequestLeave request)
        {
            return _requestLeaveRepository.RequestLeave(request);
        }

        [HttpPut("update-leave/{id}")]
        public IActionResult UpdateLeave(RequestLeave request, int id)
        {
            return Ok(_requestLeaveRepository.UpdateRequest(request, id));
        }

        [HttpPut("emp-leaves/{id}")]
        public List<RequestLeave> GetLeaveById(int id)
        {
            return _requestLeaveRepository.GetLeaveById(id);
        }
    }

}
