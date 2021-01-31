using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Data;
using Online_Shop.Models;


namespace Online_Shop.Controllers
{
    
    public class JoysticksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JoysticksController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Joysticks
        public ActionResult Index(int pg = 1, string search = "")
        {
            List<Joystick> laptops = _context.Joysticks.ToList();
            List<Joystick> laptopat = _context.Joysticks.Where(x => x.Marka.Contains(search)).ToList();

            if (search == "")
            {
                const int pageSize = 3;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = laptops.Count();

                var pager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = laptops.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                //return View(laptops);

                return View(data);

            }
            if (_context.Joysticks.Where(x => x.Marka.Contains(search)).ToList() != null)
            {
                //const int pageSize = 3;
                if (pg < 1)
                {
                    pg = 1;
                }

                //int recsCount = laptopat.Count();

                //var pager = new Pager(recsCount, pg, pageSize);

                //int recSkip = (pg - 1) * pageSize;

                //var data = laptopat.Skip(recSkip).Take(pager.PageSize).ToList();

                //this.ViewBag.Pager = pager;

                //return View(data);
                return View(_context.Joysticks.Where(x => x.Marka.Contains(search)).ToList());
            }

            return View(_context.Joysticks.Where(x => x.Marka.Contains(search)).ToList());
        }

        // GET: Joysticks/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joystick = await _context.Joysticks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joystick == null)
            {
                return NotFound();
            }

            return View(joystick);
        }

        // GET: Joysticks/Create
        [Authorize(Roles = "Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Joysticks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Modeli,Ngjyra,Image,BatterySize,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Joystick joystick)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joystick);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joystick);
        }

        // GET: Joysticks/Edit/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joystick = await _context.Joysticks.FindAsync(id);
            if (joystick == null)
            {
                return NotFound();
            }
            return View(joystick);
        }

        // POST: Joysticks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Modeli,Ngjyra,Image,BatterySize,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Joystick joystick)
        {
            if (id != joystick.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joystick);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoystickExists(joystick.Id))
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
            return View(joystick);
        }

        // GET: Joysticks/Delete/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joystick = await _context.Joysticks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joystick == null)
            {
                return NotFound();
            }

            return View(joystick);
        }

        // POST: Joysticks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joystick = await _context.Joysticks.FindAsync(id);
            _context.Joysticks.Remove(joystick);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoystickExists(int id)
        {
            return _context.Joysticks.Any(e => e.Id == id);
        }
    }
}
