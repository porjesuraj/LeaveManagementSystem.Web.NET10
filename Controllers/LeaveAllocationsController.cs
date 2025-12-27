using LeaveManagementSystem.Web.Models;
using LeaveManagementSystem.Web.ServiceLayer.LeaveAllocation;
using LeaveManagementSystem.Web.ServiceLayer.LeaveType;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationsController(ILeaveAllocationsService _leaveAllocationsService, ILeaveTypeService _leaveTypeService) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var employees = await _leaveAllocationsService.GetEmployees();
            return View(employees);
        }

        public async Task<IActionResult> Details(string? userId)
        {
           var employeeVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);

            return View(employeeVM);
        }

        [Authorize(Roles = Roles.Administrator + "," + Roles.Supervisor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            await _leaveAllocationsService.AllocateLeave(id);
            return RedirectToAction(nameof(Details), new {userId = id});
        }

        public async Task<IActionResult> EditAllocation(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var allocation = await _leaveAllocationsService.GetEmployeeAllocation(id.Value);
            if(allocation == null)
            {
                return NotFound();
            }
            return View(allocation);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveEditAllocationVM allocationEdirVm)
        {
            if( await _leaveTypeService.DaysExceedMaximumAllowed(allocationEdirVm.LeaveType.Id, allocationEdirVm.NumberOfDays))
            {
                ModelState.AddModelError("NumberOfDays", "The allocation exceeds the maximum number of days allowed for this leave type") ;
            }

            if (ModelState.IsValid)
            {
                await _leaveAllocationsService.EditAllocation(allocationEdirVm);

                return RedirectToAction(nameof(Details), new { userId = allocationEdirVm.Employee.Id });
            }

            var days = allocationEdirVm.NumberOfDays;

            var allocation = await _leaveAllocationsService.GetEmployeeAllocation(allocationEdirVm.Id);
            allocation.NumberOfDays = days;

            return View(allocation);


        }


    }
}
