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
    
    public class HeadsetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadsetsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Headsets
        public ActionResult Index(int pg = 1, string search = "")
        {
            List<Headset> laptops = _context.Headsets.ToList();
            List<Headset> laptopat = _context.Headsets.Where(x => x.Marka.Contains(search)).ToList();

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
            if (_context.Headsets.Where(x => x.Marka.Contains(search)).ToList() != null)
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
                return View(_context.Headsets.Where(x => x.Marka.Contains(search)).ToList());
            }

            return View(_context.Headsets.Where(x => x.Marka.Contains(search)).ToList());
        }

        // GET: Headsets/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headset = await _context.Headsets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headset == null)
            {
                return NotFound();
            }

            return View(headset);
        }

        // GET: Headsets/Create
        [Authorize(Roles = "Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Headsets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Modeli,Ngjyra,Image,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Headset headset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headset);
        }

        // GET: Headsets/Edit/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headset = await _context.Headsets.FindAsync(id);
            if (headset == null)
            {
                return NotFound();
            }
            return View(headset);
        }

        // POST: Headsets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Modeli,Ngjyra,Image,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Headset headset)
        {
            if (id != headset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadsetExists(headset.Id))
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
            return View(headset);
        }

        // GET: Headsets/Delete/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headset = await _context.Headsets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headset == null)
            {
                return NotFound();
            }

            return View(headset);
        }

        // POST: Headsets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headset = await _context.Headsets.FindAsync(id);
            _context.Headsets.Remove(headset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeadsetExists(int id)
        {
            return _context.Headsets.Any(e => e.Id == id);
        }
    }
}
