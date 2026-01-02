using LeaveManagementSystem.Web.Models.LeaveRequest;
using LeaveManagementSystem.Web.ServiceLayer.LeaveRequest;
using LeaveManagementSystem.Web.ServiceLayer.LeaveType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController(ILeaveTypeService _leaveTypeService, ILeaveRequestsService _leaveRequestsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var employeeRequests = await  _leaveRequestsService.GetEmployeeLeaveRequests();
            return View(employeeRequests);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var leaveTypes = await _leaveTypeService.GetAllLeaveAsnyc();

            var leaveTypeList = new SelectList(leaveTypes, "Id", "Name"); 

            var data = new LeaveRequestCreateVM
            {
                LeaveTypes = leaveTypeList,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))             
            };

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM leaveRequestCreateVM)
        {
         
            if(await _leaveRequestsService.RequestDatesExceedAllocation(leaveRequestCreateVM))
            {
                ModelState.AddModelError(nameof(leaveRequestCreateVM.EndDate), "You do not have sufficient leave allocation for the selected dates.");
                ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
            }
            if (ModelState.IsValid)
            {
               await _leaveRequestsService.CreateLeaveRequest(leaveRequestCreateVM);
                return RedirectToAction(nameof(Index));
            }

            var leaveTypes = await _leaveTypeService.GetAllLeaveAsnyc();

            var leaveTypeList = new SelectList(leaveTypes, "Id", "Name");

            leaveRequestCreateVM.LeaveTypes = leaveTypeList;

            return View(leaveRequestCreateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int Id)
        {
          await _leaveRequestsService.CancelLeaveRequest(Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ListRequest()
        {
            var model = await _leaveRequestsService.AdminGetAllLeaveRequests();
            return View(model);
        }

        public async Task<IActionResult> Review(int id)
        {

         var model =   await _leaveRequestsService.GetLeaveRequestForReview(id);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Review(int id, bool approved)
        {
            await _leaveRequestsService.ReviewLeaveRequest(id, approved);
            return RedirectToAction(nameof(ListRequest));
        }



    }
}
