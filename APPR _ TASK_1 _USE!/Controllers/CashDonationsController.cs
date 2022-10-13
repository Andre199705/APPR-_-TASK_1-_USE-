using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR___TASK_1__USE_.Data;
using APPR___TASK_1__USE_.Models;
using Microsoft.AspNetCore.Authorization;

namespace APPR___TASK_1__USE_.Controllers 

{
    //(Esposito and Esposito, 2022)
    [Authorize]
    public class CashDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CashDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CashDonations
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashDonations.ToListAsync());
        }

        // GET: CashDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDonations = await _context.CashDonations
                .FirstOrDefaultAsync(m => m.user == id);
            if (cashDonations == null)
            {
                return NotFound();
            }

            return View(cashDonations);
        }

        // GET: CashDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user,Date,Time,Amount,Annonymys")] CashDonations cashDonations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashDonations);
        }

        // GET: CashDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDonations = await _context.CashDonations.FindAsync(id);
            if (cashDonations == null)
            {
                return NotFound();
            }
            return View(cashDonations);
        }

        // POST: CashDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user,Date,Time,Amount,Annonymys")] CashDonations cashDonations)
        {
            if (id != cashDonations.user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDonationsExists(cashDonations.user))
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
            return View(cashDonations);
        }

        // GET: CashDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDonations = await _context.CashDonations
                .FirstOrDefaultAsync(m => m.user == id);
            if (cashDonations == null)
            {
                return NotFound();
            }

            return View(cashDonations);
        }

        // POST: CashDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDonations = await _context.CashDonations.FindAsync(id);
            _context.CashDonations.Remove(cashDonations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashDonationsExists(int id)
        {
            return _context.CashDonations.Any(e => e.user == id);
        }
    }
}
