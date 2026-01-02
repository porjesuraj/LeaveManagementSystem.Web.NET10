
using LeaveManagementSystem.Web.Models;

namespace LeaveManagementSystem.Web.ServiceLayer.LeaveAllocation
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);

        Task  EditAllocation(LeaveEditAllocationVM allocationEdirVm);
        Task<List<Data.LeaveAllocation>> GetAllocations(string? userId);
        Task<Data.LeaveAllocation> GetCurrentALlocation(int leaveTypeId, string employeeId);
        Task<LeaveEditAllocationVM> GetEmployeeAllocation(int allocationId);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
        Task<List<EmployeeListVM>> GetEmployees();
    }
}
