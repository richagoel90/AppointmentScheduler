using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppointmentConsoleApp;

namespace AppointmentSchedulerUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentContext _context = new AppointmentContext();

        
        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            var appointmentContext = _context.Appointments.Include(a => a.User);
            return View(await appointmentContext.ToListAsync());
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentInfo = await _context.Appointments
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointmentInfo == null)
            {
                return NotFound();
            }

            return View(appointmentInfo);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            ViewData["HostUserID"] = new SelectList(_context.Users, "UserId", "EmailID");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentID,HostUser,GuestUser,DatenTime,Subject,Status,HostUserID")] AppointmentInfo appointmentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HostUserID"] = new SelectList(_context.Users, "UserId", "EmailID", appointmentInfo.HostUserID);
            return View(appointmentInfo);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentInfo = await _context.Appointments.FindAsync(id);
            if (appointmentInfo == null)
            {
                return NotFound();
            }
            ViewData["HostUserID"] = new SelectList(_context.Users, "UserId", "EmailID", appointmentInfo.HostUserID);
            return View(appointmentInfo);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentID,HostUser,GuestUser,DatenTime,Subject,Status,HostUserID")] AppointmentInfo appointmentInfo)
        {
            if (id != appointmentInfo.AppointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentInfoExists(appointmentInfo.AppointmentID))
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
            ViewData["HostUserID"] = new SelectList(_context.Users, "UserId", "EmailID", appointmentInfo.HostUserID);
            return View(appointmentInfo);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentInfo = await _context.Appointments
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointmentInfo == null)
            {
                return NotFound();
            }

            return View(appointmentInfo);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentInfo = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointmentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentInfoExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentID == id);
        }
    }
}
