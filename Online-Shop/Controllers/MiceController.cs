using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Data;
using Online_Shop.Models;

namespace Online_Shop.Controllers
{
   
    public class MiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Mice
        public ActionResult Index(int pg = 1, string search = "")
        {
            List<Mouse> laptops = _context.Mice.ToList();
            List<Mouse> laptopat = _context.Mice.Where(x => x.Marka.Contains(search)).ToList();

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
            if (_context.Mice.Where(x => x.Marka.Contains(search)).ToList() != null)
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
                return View(_context.Mice.Where(x => x.Marka.Contains(search)).ToList());
            }

            return View(_context.Mice.Where(x => x.Marka.Contains(search)).ToList());
        }

        // GET: Mice/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouse = await _context.Mice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouse == null)
            {
                return NotFound();
            }

            return View(mouse);
        }

        // GET: Mice/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Modeli,Ngjyra,Image,RgbLight,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Mouse mouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mouse);
        }

        // GET: Mice/Edit/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouse = await _context.Mice.FindAsync(id);
            if (mouse == null)
            {
                return NotFound();
            }
            return View(mouse);
        }

        // POST: Mice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Modeli,Ngjyra,Image,RgbLight,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Mouse mouse)
        {
            if (id != mouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouseExists(mouse.Id))
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
            return View(mouse);
        }

        // GET: Mice/Delete/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouse = await _context.Mice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouse == null)
            {
                return NotFound();
            }

            return View(mouse);
        }

        // POST: Mice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mouse = await _context.Mice.FindAsync(id);
            _context.Mice.Remove(mouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouseExists(int id)
        {
            return _context.Mice.Any(e => e.Id == id);
        }
    }
}
