using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.ServiceLayer.LeaveType
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveReadOnlyViewModel>> GetAllLeaveAsnyc();

        Task<T?> GetByIdAsync<T>(int id) where T: class;

        Task Create(LeaveTypeCreateVM leaveTypeCreateVm);

        Task Edit(LeaveTypeEditVM leaveTypeEditVm);

        Task Remove(int id);
        bool LeaveTypeExists(int id);
        bool CheckLeaveNameTypeExist(LeaveTypeEditVM leaveTypeEditVM);
        bool CheckLeaveNameTypeExist(string name);
    }
}
