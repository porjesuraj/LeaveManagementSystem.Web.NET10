using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.ServiceLayer.LeaveAllocation
{

    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);
    }
    public class LeaveAllocationsService(ApplicationDbContext _context) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
           var leaveTypes = await _context.LeaveTypes.ToListAsync();

            var period =  await _context.Periods.SingleAsync(q => q.EndDate.Year == DateTime.Now.Year);

            var monthRemaining = period.EndDate.Month - DateTime.Now.Month;
            foreach (var leaveType in  leaveTypes)
            {
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);

                var allocation = new Data.LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    NumberOfDays = (int)Math.Round(accuralRate * monthRemaining),
                    DateCreated = DateTime.Now
                };

                 _context.LeaveAllocations.Add(allocation);
            }

            await _context.SaveChangesAsync();

        }
    }
}
