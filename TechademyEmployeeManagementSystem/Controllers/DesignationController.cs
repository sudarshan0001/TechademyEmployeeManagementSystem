using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;
using TechademyEmployeeManagementSystem.Repository.Services;

namespace TechademyEmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _designationRepository;
        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        [HttpGet("AllDesignations")]
        public IEnumerable AllDesignation()
        {
            var des = _designationRepository.GetAllDesignations();
            return des;
        }

        [HttpPost("AddDesignation")]
        public string AddDesignation([FromBody]DesignationModel designationModel)
        {
            var des = _designationRepository.AddDesignation(designationModel);
            return des;
        }

        [HttpDelete("DeleteDesignation/{id}")]
        public IActionResult DeleteDesignation(int id)
        {
            var des = _designationRepository.DeleteDesignation(id);
            return Ok(des);
        }

        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult Update([FromBody] DesignationModel designationModel, int id)
        {
            var des = _designationRepository.UpdateDesignation(designationModel, id);
            return Ok(des);
        }
    }
}
