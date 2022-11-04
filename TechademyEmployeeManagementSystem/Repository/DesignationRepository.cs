using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagementSystem.Data;
using TechademyEmployeeManagementSystem.Models;
using TechademyEmployeeManagementSystem.Repository.Services;

namespace TechademyEmployeeManagementSystem.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly appDbContext _dbContext;
        public DesignationRepository(appDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable GetAllDesignations()
        {
            var designation = _dbContext.designation.ToList();
            return designation;
        }

        public string AddDesignation(DesignationModel designationModel)
        {
            try
            {
                if (designationModel == null)
                {
                    return "NO Data Supplied";
                }
                _dbContext.designation.Add(designationModel);
                _dbContext.SaveChanges();
                return "successfully Added new Designation";
            }
            catch
            {
                return "Something went wrong while Adding New Designation";
            }
        }
        public DesignationModel GetByDesignationId(int Id)
        {
            var des = _dbContext.designation.FirstOrDefault(t =>
               t.DesignationId == Id);
            return des;
        }

        public DesignationModel GetByRoleName(string name)
        {
            var des = _dbContext.designation.FirstOrDefault(t => t.RoleName == name);
            return des;
        }

        public string DeleteDesignation(int id)
        {
            try
            {
                var des = _dbContext.designation.FirstOrDefault(t => t.DesignationId == id);
                if (des == null)
                {
                    return "Record Not Found";
                }

                _dbContext.designation.Remove(des);
                _dbContext.SaveChanges();
                return "Record successfully deleted";
            }
            catch
            {
                return "error occurred while accessing database or an object of data";
            }
        }

        public string UpdateDesignation(DesignationModel designationModel, int id)
        {
            try
            {
                if (designationModel == null || designationModel.DesignationId != id)
                {
                    return "No Data supplied to an Object OR No Id mentioned in the input";
                }

                var des = _dbContext.designation.FirstOrDefault(t => t.DesignationId == id);
                if (des == null)
                {
                    return "Record Not Found";
                }
                //des.DesignationId = designationModel.DesignationId;
                des.DesignationName = designationModel.DesignationName;
                des.RoleName = designationModel.RoleName;
                des.DepartmentName = designationModel.DepartmentName;


                _dbContext.designation.Update(des);
                _dbContext.SaveChanges();
                return "Record Successfully Updated";
            }
            catch
            {
                return "Something went wrong updating a record";
            }
        }
    }
}
