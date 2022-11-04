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
    public class LeaveRequestRepository : IRequestLeaveRepository
    {
        private readonly appDbContext _dbContext;
        public LeaveRequestRepository(appDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //for Manager to approve leave
        public List<RequestLeave> GetAllLeave()
        {
            var leaves = _dbContext.Leave.Where(t => t.LeaveStatus == "In-Process").ToList();
            return leaves;
        }
 
        //for Employee fetch his/her all leave history
        public List<RequestLeave> GetLeaveById(int id)
        {
            return _dbContext.Leave.Where(t => t.EmployeeId == id).ToList();
        }

        public string RequestLeave(RequestLeave request)
        {
            try
            {
                if (request == null)
                {
                    return "NO Data Supplied";
                }
                _dbContext.Leave.Add(request);
                _dbContext.SaveChanges();
                return "Your Request for Leave is processed please wait..";
            }
            catch
            {
                return "Something went wrong";
            }
        }

        public string UpdateRequest(RequestLeave request, int id)
        {
            try
            {
                if (request == null || request.LeaveId != id)
                {
                    return "No Data supplied to an Object OR No Id mentioned in the input";
                }

                var leave = _dbContext.Leave.FirstOrDefault(t => t.LeaveId == id);
                if (leave == null)
                {
                    return "Record Not Found";
                }
                leave.LeaveId = request.LeaveId;
                leave.LeaveType = request.LeaveType;
                leave.LeaveDays = request.LeaveDays;
                leave.LeaveReason = request.LeaveReason;
                leave.FromDate = request.FromDate;
                leave.LeaveStatus = request.LeaveStatus;
                leave.EmployeeId = request.EmployeeId;

                _dbContext.Leave.Update(leave);
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
