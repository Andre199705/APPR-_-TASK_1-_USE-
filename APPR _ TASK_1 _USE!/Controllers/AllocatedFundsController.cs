using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR___TASK_1__USE_.Data;
using APPR___TASK_1__USE_.Models;

namespace APPR___TASK_1__USE_.Controllers
{
    public class AllocatedFundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllocatedFundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllocatedFunds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AllocatedFunds.Include(a => a.CashDonations).Include(a => a.Disaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AllocatedFunds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocatedFunds = await _context.AllocatedFunds
                .Include(a => a.CashDonations)
                .Include(a => a.Disaster)
                .FirstOrDefaultAsync(m => m.id == id);
            if (allocatedFunds == null)
            {
                return NotFound();
            }

            return View(allocatedFunds);
        }

        // GET: AllocatedFunds/Create
        public IActionResult Create()
        {
            ViewData["user"] = new SelectList(_context.CashDonations, "user", "user");
            ViewData["TDisaster"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster");
            return View();
        }

        // POST: AllocatedFunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Date,TDisaster,user")] AllocatedFunds allocatedFunds)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocatedFunds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["user"] = new SelectList(_context.CashDonations, "user", "user", allocatedFunds.user);
            ViewData["TDisaster"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster", allocatedFunds.TDisaster);
            return View(allocatedFunds);
        }

        // GET: AllocatedFunds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocatedFunds = await _context.AllocatedFunds.FindAsync(id);
            if (allocatedFunds == null)
            {
                return NotFound();
            }
            ViewData["user"] = new SelectList(_context.CashDonations, "user", "user", allocatedFunds.user);
            ViewData["TDisaster"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster", allocatedFunds.TDisaster);
            return View(allocatedFunds);
        }

        // POST: AllocatedFunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Date,TDisaster,user")] AllocatedFunds allocatedFunds)
        {
            if (id != allocatedFunds.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocatedFunds);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocatedFundsExists(allocatedFunds.id))
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
            ViewData["user"] = new SelectList(_context.CashDonations, "user", "user", allocatedFunds.user);
            ViewData["TDisaster"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster", allocatedFunds.TDisaster);
            return View(allocatedFunds);
        }

        // GET: AllocatedFunds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocatedFunds = await _context.AllocatedFunds
                .Include(a => a.CashDonations)
                .Include(a => a.Disaster)
                .FirstOrDefaultAsync(m => m.id == id);
            if (allocatedFunds == null)
            {
                return NotFound();
            }

            return View(allocatedFunds);
        }

        // POST: AllocatedFunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocatedFunds = await _context.AllocatedFunds.FindAsync(id);
            _context.AllocatedFunds.Remove(allocatedFunds);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocatedFundsExists(int id)
        {
            return _context.AllocatedFunds.Any(e => e.id == id);
        }
    }
}
