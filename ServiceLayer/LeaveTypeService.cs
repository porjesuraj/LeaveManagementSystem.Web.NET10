using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LeaveManagementSystem.Web.ServiceLayer
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


    public class LeaveTypeService : ILeaveTypeService
    {
        public LeaveTypeService(ApplicationDbContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }

        public ApplicationDbContext _context { get; }
        public IMapper _mapper { get; }


        public async Task<IEnumerable<LeaveReadOnlyViewModel>> GetAllLeaveAsnyc()
        {
            var leaveTypes = await _context.LeaveTypes.ToListAsync();     

            var viewData = _mapper.Map<List<LeaveReadOnlyViewModel>>(leaveTypes);

            return viewData;
        }

        public async Task<LeaveReadOnlyViewModel?> GetLeaveTypeIdAsync(int? id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return null;
            }

            var viewData = _mapper.Map<LeaveReadOnlyViewModel>(leaveType);
            return viewData;
        }

        public async Task Create(LeaveTypeCreateVM leaveTypeCreateVm)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeCreateVm);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(LeaveTypeEditVM leaveTypeEditVm)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeEditVm);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }

        public async Task  Remove(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
                _context.SaveChanges();

            }

        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(lt => lt.Id.Equals(id));
            if (data == null)
            {
                return null;
            }

            var viewData = _mapper.Map<T>(data);
            return viewData;

        }


        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        public bool CheckLeaveNameTypeExist(LeaveTypeEditVM leaveTypeEditVM)
        {
            return _context.LeaveTypes.Any(lt => (lt.Name.ToLower() == (leaveTypeEditVM.Name.ToLower()) && (lt.Id != leaveTypeEditVM.Id)));
        }

        public bool CheckLeaveNameTypeExist(string name)
        {
            return _context.LeaveTypes.Any(lt => lt.Name.ToLower() == name.ToLower());
        }
    }
}
