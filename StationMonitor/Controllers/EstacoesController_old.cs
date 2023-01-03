using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StationMonitor.Data;
using StationMonitor.Entidades;

namespace StationMonitor.Controllers
{

    [Authorize]
    public class EstacoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;


        public EstacoesController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Estacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stations.ToListAsync());
        }

        // GET: Estacoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacao = await _context.Stations.FirstOrDefaultAsync(m => m.Id == id);

            if (estacao == null)
            {
                return NotFound();
            }

            return View(estacao);
        }

        // GET: Estacoes/Create
        public IActionResult Create()
        {
            var user =  _manager.GetUserAsync(HttpContext.User).Result;
            var grupos =  _context.Groups.Include(x=>x.User).Where(x => x.User.Id == user.Id).ToList();
            ViewData["grupos"] = grupos;// new SelectList(grupos, "Id", "Name");
            return View();
        }

        // POST: Estacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Processador,PlacaMae,Memoria")] Station estacao)
        {
            ModelState.Remove("User");

            var errors = ModelState
    .Where(x => x.Value.Errors.Count > 0)
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();

            var user = await _manager.GetUserAsync(HttpContext.User);
            estacao.User = user;
            
            if (ModelState.IsValid)
            {
                estacao.Id = Guid.NewGuid();
                _context.Add(estacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }





            return View(estacao);
        }

        // GET: Estacoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacao = await _context.Stations.FindAsync(id);
            if (estacao == null)
            {
                return NotFound();
            }
            return View(estacao);
        }

        // POST: Estacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Processador,PlacaMae,Memoria")] Station estacao)
        {
            if (id != estacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacaoExists(estacao.Id))
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
            return View(estacao);
        }

        // GET: Estacoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacao = await _context.Stations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacao == null)
            {
                return NotFound();
            }

            return View(estacao);
        }

        // POST: Estacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estacao = await _context.Stations.FindAsync(id);
            _context.Stations.Remove(estacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacaoExists(Guid id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }
    }
}
