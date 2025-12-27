using AutoMapper;
using LeaveManagementSystem.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.ServiceLayer.LeaveAllocation
{
    public class LeaveAllocationsService(ApplicationDbContext _context,
        IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager, IMapper _mapper) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            var leaveTypes = await _context.LeaveTypes.
                Where(q => !q.LeaveAllocations.Any(l => l.EmployeeId == employeeId))
                .ToListAsync();

            //var todayMonth = new DateOnly(2026, 12, 12);
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == DateTime.Now.Year);
           // var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == todayMonth.Year);

           // int todayMonth = new DateOnly(2026, 12, 12).Month;
           // var monthRemaining = period.EndDate.Month - todayMonth.Month;
          //  var monthRemaining = period.EndDate.Month - todayMonth.Month;

            var monthRemaining = period.EndDate.Month - DateTime.Now.Month;
            foreach (var leaveType in leaveTypes)
            {
                /*var allocationExists = await AllocationExists(employeeId, period.Id, leaveType.Id);
                if (allocationExists)
                    continue;*/

                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);


                var numberOfDaysToAllocate = (int)Math.Round(accuralRate * monthRemaining);
                var actuals = numberOfDaysToAllocate == 0 ? 10 : numberOfDaysToAllocate;
                var allocation = new Data.LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    NumberOfDays = actuals,
                    DateCreated = DateTime.Now
                };
                _context.LeaveAllocations.Add(allocation);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Data.LeaveAllocation>> GetAllocations(string? userId)
        {
            //  var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

            // var user = await _userManager.FindByNameAsync(userName);

            string employeeId = string.Empty;
            if (!string.IsNullOrEmpty(userId))
            {
                employeeId = userId;
            }
            else
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

                employeeId = user.Id;
            }
               

            var leaveAllocations = await _context.LeaveAllocations
                .Where(q => q.EmployeeId == employeeId)
                .Include(q => q.LeaveType)
                .Include(q => q.Period)
                .Include(q => q.Employee)

                .ToListAsync();

            return leaveAllocations;
        }

       

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? id)
        {
            var user = string.IsNullOrEmpty(id) ?   await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User) :
                await _userManager.FindByIdAsync(id);


            var allocations = await GetAllocations(user.Id);

            var allocationVmList = _mapper.Map<List<Data.LeaveAllocation>, List<LeaveAllocationVM>>(allocations);

            var leaveTypesCount = await _context.LeaveTypes.CountAsync();



            var employeeAllocationVm = new EmployeeAllocationVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count
            };

            return employeeAllocationVm;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);

            var employeeList = _mapper.Map<List<EmployeeListVM>>(users);

            return employeeList;

        }

        public async Task<LeaveEditAllocationVM> GetEmployeeAllocation(int allocationId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(q => q.Employee)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveEditAllocationVM>(allocations);

            return model;
        }

        private async Task<bool> AllocationExists(string userId, int periodId, int LeaveTypeId)
        {
            var exist = await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId && q.PeriodId == periodId && q.LeaveTypeId == LeaveTypeId);

            return exist;
        }

        public  async Task EditAllocation(LeaveEditAllocationVM allocationEdirVm)
        {
            /*var leaveAllocation = await GetEmployeeAllocation(allocationEdirVm.Id);

            if(leaveAllocation == null)
            {
                throw new Exception("Record not found");
            }

            var leaveAllocationModel = _mapper.Map<Data.LeaveAllocation>(leaveAllocation);
            leaveAllocationModel.NumberOfDays = allocationEdirVm.NumberOfDays;*/
            //  _context.LeaveAllocations.Update(leaveAllocationModel);
            //_context.Entry(leaveAllocationModel).State = EntityState.Modified;
          //  await _context.SaveChangesAsync();

           await  _context.LeaveAllocations
                .Where(q => q.Id == allocationEdirVm.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(w => w.NumberOfDays, allocationEdirVm.NumberOfDays));


        }


    
    }
}
