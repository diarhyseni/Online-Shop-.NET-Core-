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
    
    public class GameConsolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameConsolesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: GameConsoles
        public ActionResult Index(int pg = 1, string search = "")
        {
            List<GameConsole> laptops = _context.GameConsoles.ToList();
            List<GameConsole> laptopat = _context.GameConsoles.Where(x => x.Marka.Contains(search)).ToList();

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
            if (_context.GameConsoles.Where(x => x.Marka.Contains(search)).ToList() != null)
            {
                //const int pageSize = 3;
                //if (pg < 1)
                //{
                //    pg = 1;
                //}

                //int recsCount = laptopat.Count();

                //var pager = new Pager(recsCount, pg, pageSize);

                //int recSkip = (pg - 1) * pageSize;

                //var data = laptopat.Skip(recSkip).Take(pager.PageSize).ToList();

                //this.ViewBag.Pager = pager;

                //return View(data);
                return View(_context.GameConsoles.Where(x => x.Marka.Contains(search)).ToList());
            }

            return View(_context.GameConsoles.Where(x => x.Marka.Contains(search)).ToList());
        }

        // GET: GameConsoles/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.GameConsoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            return View(gameConsole);
        }

        // GET: GameConsoles/Create
        [Authorize(Roles = "Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameConsoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Modeli,Ngjyra,Image,Cpu,Ram,Storage,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] GameConsole gameConsole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameConsole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameConsole);
        }

        // GET: GameConsoles/Edit/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.GameConsoles.FindAsync(id);
            if (gameConsole == null)
            {
                return NotFound();
            }
            return View(gameConsole);
        }

        // POST: GameConsoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Modeli,Ngjyra,Image,Cpu,Ram,Storage,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] GameConsole gameConsole)
        {
            if (id != gameConsole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameConsole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameConsoleExists(gameConsole.Id))
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
            return View(gameConsole);
        }

        // GET: GameConsoles/Delete/5
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.GameConsoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            return View(gameConsole);
        }

        // POST: GameConsoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameConsole = await _context.GameConsoles.FindAsync(id);
            _context.GameConsoles.Remove(gameConsole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameConsoleExists(int id)
        {
            return _context.GameConsoles.Any(e => e.Id == id);
        }
    }
}
