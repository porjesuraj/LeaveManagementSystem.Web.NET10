using AutoMapper;
using Azure.Core;
using LeaveManagementSystem.Web.Models.LeaveRequest;
using LeaveManagementSystem.Web.ServiceLayer.LeaveAllocation;
using LeaveManagementSystem.Web.ServiceLayer.Periods;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.ServiceLayer.LeaveRequest
{
    public class LeaveRequestsService(IMapper _mapper, UserManager<ApplicationUser> _userManager,
        IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _context, IPeriodService _periodService, ILeaveAllocationsService _leaveAllocationsService) : ILeaveRequestsService
    {
        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);

            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Cancelled;

            // restore allocation days based on request
           /* var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;

            var period = await _periodService.GetCurrentPeriod();
            var allocationToRestore = await _context.LeaveAllocations.FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId && q.EmployeeId == leaveRequest.EmployeeId && q.PeriodId == period.Id);

            allocationToRestore.NumberOfDays += numberOfDays;*/

            // restore allocation days based on request
           await UpdateAllocationDays(leaveRequest, false);

            await   _context.SaveChangesAsync();
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM leaveRequestCreateVM)
        {
           // map data to leave request data model 
           // get logged in employee id
           // set LeaveRequestStatusId to pending

            // save leave request

           var request =  _mapper.Map<Data.LeaveRequest>(leaveRequestCreateVM);

            var user = await  _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            
            request.EmployeeId = user.Id;

            request.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;

             _context.LeaveRequests.Add(request);

            /*  var period = await _periodService.GetCurrentPeriod();


              var numberOfDays = request.EndDate.DayNumber - request.StartDate.DayNumber;

              var allocationToDeduct = await  _context.LeaveAllocations.FirstOrDefaultAsync(q => q.LeaveTypeId == leaveRequestCreateVM.LeaveTypeId 
              && q.EmployeeId == user.Id && q.PeriodId == period.Id);

              if(allocationToDeduct != null)
              {
                  allocationToDeduct.NumberOfDays -= numberOfDays;
                  _context.LeaveAllocations.Update(allocationToDeduct);
              }*/

           await UpdateAllocationDays(request, true);    
            await _context.SaveChangesAsync();

        }

        public async Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var leaveRequests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Include(q => q.LeaveRequestStatus)
                .ToListAsync();

            var leaveRequestModel = leaveRequests.Select(q => new LeaveRequestListVM
            {
                StartDate = q.StartDate,
                EndDate = q.EndDate,
                Id = q.Id,
                LeaveType = q.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestStatusId,
                NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
            }).ToList();
            var model = new EmployeeLeaveRequestListVM
            {
                ApprovedRequests = leaveRequests.Count(q => q.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Approved),
                PendingRequests = leaveRequests.Count(q => q.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Pending),
                RejectedRequests = leaveRequests.Count(q => q.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Rejected),
                TotalRequests = leaveRequests.Count,
                LeaveRequests = leaveRequestModel

            };

            return model;
        }

        public async Task<IEnumerable<LeaveRequestListVM>> GetEmployeeLeaveRequests()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var leaveRequests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Include(q => q.LeaveRequestStatus)
                .Where(q => q.EmployeeId == user.Id)
                .ToListAsync();

            var model = leaveRequests.Select(q => new LeaveRequestListVM
            {
                StartDate = q.StartDate,
                EndDate = q.EndDate,
                Id = q.Id,
                LeaveType = q.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestStatusId,
                NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
            });

            return model;
        }

        public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
        {
           var numberOfDaysRequested = model.EndDate.DayNumber - model.StartDate.DayNumber;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var period = await _periodService.GetCurrentPeriod();


            var allocation = await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.LeaveTypeId == model.LeaveTypeId
            && q.EmployeeId == user.Id && q.PeriodId == period.Id);

            return allocation.NumberOfDays < numberOfDaysRequested; 
        }

        public async Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
        {

            var leaveRequest = await _context.LeaveRequests.Include(q => q.LeaveType)
                .FirstAsync(q => q.Id == id);


            var user = await _userManager.FindByIdAsync(leaveRequest.EmployeeId);

            var model = new ReviewLeaveRequestVM
            {
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                LeaveRequestStatus = (LeaveRequestStatusEnum)leaveRequest.LeaveRequestStatusId,
                Id = leaveRequest.Id,
                LeaveType = leaveRequest.LeaveType.Name,
                Employee = new Models.EmployeeListVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName

                }
            };

            return model;

        }

        public async Task ReviewLeaveRequest(int id, bool approved)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);


            leaveRequest.LeaveRequestStatusId = (int)(approved ? LeaveRequestStatusEnum.Approved : LeaveRequestStatusEnum.Rejected);


            leaveRequest.ReviewerId = user.Id;

            if (!approved)
            {
                /* var period = await _periodService.GetCurrentPeriod();


                     var allocation = await _context.LeaveAllocations.FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId && q.EmployeeId == leaveRequest.EmployeeId && q.PeriodId == period.Id);

                     allocation.NumberOfDays += (leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber);*/

             await   UpdateAllocationDays(leaveRequest, false);
            }

            await _context.SaveChangesAsync();

        }


        private async Task UpdateAllocationDays(Data.LeaveRequest leaveRequest, bool deductDays)
        {
            var allocation = await _leaveAllocationsService.GetCurrentALlocation(leaveRequest.LeaveTypeId, leaveRequest.EmployeeId);

            var numberOfDays = CalculateDays(leaveRequest.StartDate, leaveRequest.EndDate);
            if (deductDays)
            {
                allocation.NumberOfDays -= numberOfDays;
            }
            else
            {
                allocation.NumberOfDays += numberOfDays;
            }

            _context.Entry(allocation).State = EntityState.Modified;
          
        }

        private int CalculateDays(DateOnly start,DateOnly end)
        {
            return end.DayNumber - start.DayNumber;
        }
    }
}
