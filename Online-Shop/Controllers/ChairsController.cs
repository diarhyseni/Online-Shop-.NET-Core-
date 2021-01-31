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
   
    public class ChairsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChairsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Chairs
        public ActionResult Index(int pg = 1, string search = "")
        {
            List<Chair> laptops = _context.Chairs.ToList();
            List<Chair> laptopat = _context.Chairs.Where(x => x.Marka.Contains(search)).ToList();

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
            if (_context.Chairs.Where(x => x.Marka.Contains(search)).ToList() != null)
            {
                //const int pageSize = 3;
                //if (pg < 1)
                //{
                //   pg = 1;
                //}

                //int recsCount = laptopat.Count();

                //var pager = new Pager(recsCount, pg, pageSize);

                //int recSkip = (pg - 1) * pageSize;

                //var data = laptopat.Skip(recSkip).Take(pager.PageSize).ToList();

                //this.ViewBag.Pager = pager;

                //return View(data);
                return View(_context.Chairs.Where(x => x.Marka.Contains(search)).ToList());
            }

            return View(_context.Chairs.Where(x => x.Marka.Contains(search)).ToList());
        }

        // GET: Chairs/Details/5

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // GET: Chairs/Create
        [Authorize(Roles = "Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Modeli,Ngjyra,Image,LegSupport,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chair);
        }

        // GET: Chairs/Edit/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chairs.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Modeli,Ngjyra,Image,LegSupport,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Chair chair)
        {
            if (id != chair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChairExists(chair.Id))
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
            return View(chair);
        }

        // GET: Chairs/Delete/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chair = await _context.Chairs.FindAsync(id);
            _context.Chairs.Remove(chair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChairExists(int id)
        {
            return _context.Chairs.Any(e => e.Id == id);
        }
    }
}
