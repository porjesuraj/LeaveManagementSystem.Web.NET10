using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.ServiceLayer.Periods
{
    public class PeriodService(ApplicationDbContext _context) : IPeriodService
    {
        public async Task<Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;

            var period = await _context.Periods.FirstAsync(q => q.EndDate.Year == currentDate.Year);

            return period;
        }
    }



}
