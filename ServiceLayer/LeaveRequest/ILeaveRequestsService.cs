using LeaveManagementSystem.Web.Models.LeaveRequest;

namespace LeaveManagementSystem.Web.ServiceLayer.LeaveRequest
{
    public interface ILeaveRequestsService
    {

        Task CreateLeaveRequest(LeaveRequestCreateVM leaveRequestCreateVM);

        Task<IEnumerable<LeaveRequestListVM>> GetEmployeeLeaveRequests();

            Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests();

        Task CancelLeaveRequest(int leaveRequestId);

        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
        Task ReviewLeaveRequest(int id, bool approved);
    }
}
