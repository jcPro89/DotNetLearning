using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RewardingApp;
using RewardingApp.Models;

namespace RewardingApp.Controllers
{
    public class AwardsController : Controller
    {
        private readonly ActivitiesDataContext _context;

        public AwardsController(ActivitiesDataContext context)
        {
            _context = context;
        }

        // GET: Awards
        public async Task<IActionResult> Index()
        {
            var activitiesDataContext = _context.Awards.Include(a => a.Activity);
            return View(await activitiesDataContext.ToListAsync());
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Awards == null)
            {
                return NotFound();
            }

            var award = await _context.Awards
                .Include(a => a.Activity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // GET: Awards/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Id");
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ActivityId")] Award award)
        {
            if (ModelState.IsValid)
            {
                _context.Add(award);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Id", award.ActivityId);
            return View(award);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Awards == null)
            {
                return NotFound();
            }

            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Id", award.ActivityId);
            return View(award);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ActivityId")] Award award)
        {
            if (id != award.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(award);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardExists(award.Id))
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
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Id", award.ActivityId);
            return View(award);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Awards == null)
            {
                return NotFound();
            }

            var award = await _context.Awards
                .Include(a => a.Activity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Awards == null)
            {
                return Problem("Entity set 'ActivitiesDataContext.Awards'  is null.");
            }
            var award = await _context.Awards.FindAsync(id);
            if (award != null)
            {
                _context.Awards.Remove(award);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardExists(int id)
        {
          return (_context.Awards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
