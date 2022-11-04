using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Models;

namespace TechademyEmployeeManagementSystem.Repository.Services
{
    public interface IDesignationRepository
    {
        public IEnumerable GetAllDesignations();
        public string AddDesignation(DesignationModel designationModel);
        public DesignationModel GetByDesignationId(int Id);
        public DesignationModel GetByRoleName(string name);
        public string DeleteDesignation(int id);
        public string UpdateDesignation(DesignationModel designationModel, int id);
    }
}
