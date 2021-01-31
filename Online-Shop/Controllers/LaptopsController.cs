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
   
    public class LaptopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaptopsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Laptops
        public ActionResult Index(int pg = 1, string search = "")
        {
            List<Laptop> laptops = _context.Laptops.ToList();
            List<Laptop> laptopat = _context.Laptops.Where(x => x.Marka.Contains(search)).ToList();

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
            if (_context.Laptops.Where(x => x.Marka.Contains(search)).ToList() != null)
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
                return View(_context.Laptops.Where(x => x.Marka.Contains(search)).ToList());
            }

            return View(_context.Laptops.Where(x => x.Marka.Contains(search)).ToList());
        }

        // GET: Laptops/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        [Authorize(Roles = "Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Modeli,Madhesia,Cpu,Ram,Storage,Graphics,Image,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Modeli,Madhesia,Cpu,Ram,Storage,Graphics,Image,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
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
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.Id == id);
        }
    }
}
