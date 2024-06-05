using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem_Final.Data;
using EmployeeManagementSystem_Final.Models;

namespace EmployeeManagementSystem_Final.Controllers
{
    public class LeaveApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveApplications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveApplication.Include(l => l.Department).Include(l => l.Designation).Include(l => l.Employee).Include(l => l.LeaveType).Include(l => l.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaveApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplications = await _context.LeaveApplication
                .Include(l => l.Department)
                .Include(l => l.Designation)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leaveApplications == null)
            {
                return NotFound();
            }

            return View(leaveApplications);
        }

        // GET: LeaveApplications/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId");
            ViewData["DesignationId"] = new SelectList(_context.Designation, "DesignationId", "DesignationId");
            ViewData["EmployeeNo"] = new SelectList(_context.Employee, "EmployeeNo", "EmployeeNo");
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveType, "LeaveTypeId", "LeaveTypeId");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId");
            return View();
        }

        // POST: LeaveApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveId,EmployeeNo,StartDate,EndDate,Duration,LeaveTypeId,DepartmentId,DesignationId,StatusId,CreatedById,CreatedOn,ModifiedById,ModifiedOn,ApprovedBy,ApprovedOn")] LeaveApplications leaveApplications)
        {
           
            leaveApplications.CreatedById = "Synnex";
            leaveApplications.CreatedOn = DateTime.Now;
            leaveApplications.ApprovedBy = "HR";
            leaveApplications.ApprovedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(leaveApplications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", leaveApplications.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designation, "DesignationId", "DesignationId", leaveApplications.DesignationId);
            ViewData["EmployeeNo"] = new SelectList(_context.Employee, "EmployeeNo", "EmployeeNo", leaveApplications.EmployeeNo);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveType, "LeaveTypeId", "LeaveTypeId", leaveApplications.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", leaveApplications.StatusId);
            return View(leaveApplications);
        }

        // GET: LeaveApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplications = await _context.LeaveApplication.FindAsync(id);
            if (leaveApplications == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", leaveApplications.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designation, "DesignationId", "DesignationId", leaveApplications.DesignationId);
            ViewData["EmployeeNo"] = new SelectList(_context.Employee, "EmployeeNo", "EmployeeNo", leaveApplications.EmployeeNo);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveType, "LeaveTypeId", "LeaveTypeId", leaveApplications.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", leaveApplications.StatusId);
            return View(leaveApplications);
        }

        // POST: LeaveApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveId,EmployeeNo,StartDate,EndDate,Duration,LeaveTypeId,DepartmentId,DesignationId,StatusId,CreatedById,CreatedOn,ModifiedById,ModifiedOn,ApprovedBy,ApprovedOn")] LeaveApplications leaveApplications)
        {
            leaveApplications.ModifiedById = "Synnex";
            leaveApplications.ModifiedOn = DateTime.Now;
            if (id != leaveApplications.LeaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveApplications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveApplicationsExists(leaveApplications.LeaveId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", leaveApplications.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designation, "DesignationId", "DesignationId", leaveApplications.DesignationId);
            ViewData["EmployeeNo"] = new SelectList(_context.Employee, "EmployeeNo", "EmployeeNo", leaveApplications.EmployeeNo);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveType, "LeaveTypeId", "LeaveTypeId", leaveApplications.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", leaveApplications.StatusId);
            return View(leaveApplications);
        }

        // GET: LeaveApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplications = await _context.LeaveApplication
                .Include(l => l.Department)
                .Include(l => l.Designation)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leaveApplications == null)
            {
                return NotFound();
            }

            return View(leaveApplications);
        }

        // POST: LeaveApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveApplications = await _context.LeaveApplication.FindAsync(id);
            if (leaveApplications != null)
            {
                _context.LeaveApplication.Remove(leaveApplications);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveApplicationsExists(int id)
        {
            return _context.LeaveApplication.Any(e => e.LeaveId == id);
        }
    }
}