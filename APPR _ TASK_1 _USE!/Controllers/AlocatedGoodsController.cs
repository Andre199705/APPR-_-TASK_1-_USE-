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
    public class AlocatedGoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlocatedGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlocatedGoods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AlocatedGoods.Include(a => a.Disaster).Include(a => a.Donations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AlocatedGoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alocatedGoods = await _context.AlocatedGoods
                .Include(a => a.Disaster)
                .Include(a => a.Donations)
                .FirstOrDefaultAsync(m => m.id == id);
            if (alocatedGoods == null)
            {
                return NotFound();
            }

            return View(alocatedGoods);
        }

        // GET: AlocatedGoods/Create
        public IActionResult Create()
        {
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster");
            ViewData["user"] = new SelectList(_context.Donations, "user", "user");
            return View();
        }

        // POST: AlocatedGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DisasterId,user")] AlocatedGoods alocatedGoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alocatedGoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster", alocatedGoods.DisasterId);
            ViewData["user"] = new SelectList(_context.Donations, "user", "user", alocatedGoods.user);
            return View(alocatedGoods);
        }

        // GET: AlocatedGoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alocatedGoods = await _context.AlocatedGoods.FindAsync(id);
            if (alocatedGoods == null)
            {
                return NotFound();
            }
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster", alocatedGoods.DisasterId);
            ViewData["user"] = new SelectList(_context.Donations, "user", "user", alocatedGoods.user);
            return View(alocatedGoods);
        }

        // POST: AlocatedGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DisasterId,user")] AlocatedGoods alocatedGoods)
        {
            if (id != alocatedGoods.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alocatedGoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlocatedGoodsExists(alocatedGoods.id))
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
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "TDisaster", "TDisaster", alocatedGoods.DisasterId);
            ViewData["user"] = new SelectList(_context.Donations, "user", "user", alocatedGoods.user);
            return View(alocatedGoods);
        }

        // GET: AlocatedGoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alocatedGoods = await _context.AlocatedGoods
                .Include(a => a.Disaster)
                .Include(a => a.Donations)
                .FirstOrDefaultAsync(m => m.id == id);
            if (alocatedGoods == null)
            {
                return NotFound();
            }

            return View(alocatedGoods);
        }

        // POST: AlocatedGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alocatedGoods = await _context.AlocatedGoods.FindAsync(id);
            _context.AlocatedGoods.Remove(alocatedGoods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlocatedGoodsExists(int id)
        {
            return _context.AlocatedGoods.Any(e => e.id == id);
        }
    }
}
