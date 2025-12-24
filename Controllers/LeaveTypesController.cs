using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveType;
using LeaveManagementSystem.Web.Common;
using LeaveManagementSystem.Web.ServiceLayer.LeaveType;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            this._leaveTypeService = leaveTypeService;

        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData = await _leaveTypeService.GetAllLeaveAsnyc();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewData = await _leaveTypeService.GetByIdAsync<LeaveReadOnlyViewModel>(id.Value);

            if(viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,NumberOfDays")] LeaveTypeCreateVM leaveTypeCreate)
        {
            if (_leaveTypeService.CheckLeaveNameTypeExist(leaveTypeCreate.Name))
            {
                ModelState.AddModelError("Name", "Leave Type with the same name already exists.");
            }

            if (ModelState.IsValid)
            {
                _ = _leaveTypeService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

   

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // var leaveType = await _context.LeaveTypes.FindAsync(id);

            var leaveTypVM = await _leaveTypeService.GetByIdAsync<LeaveTypeEditVM>(id.Value);
            return View(leaveTypVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfDays")] LeaveTypeEditVM leaveTypeEditVM)
        {
            if (id != leaveTypeEditVM.Id)
            {
                return NotFound();
            }

            
            if (_leaveTypeService.CheckLeaveNameTypeExist(leaveTypeEditVM))
            {
                ModelState.AddModelError("Name", "Leave Type with the same name already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*var leaveType = _mapper.Map<LeaveType>(leaveTypeEditVM);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();*/

                  _ =  _leaveTypeService.Edit(leaveTypeEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! _leaveTypeService.LeaveTypeExists(leaveTypeEditVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEditVM);
        }


        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeService.GetByIdAsync<LeaveType>(id.Value); 

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _leaveTypeService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
