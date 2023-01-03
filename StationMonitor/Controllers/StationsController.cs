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
using StationMonitor.Extensions;

namespace StationMonitor.Controllers
{
    [Authorize]
    public class StationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;


        public StationsController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Stations
        public async Task<IActionResult> Index()
        {
            var user = _manager.GetUserAsync(HttpContext.User).Result;
            var lista = await _context.Stations.Include(x => x.User).Include(x => x.Events).Where(x => x.User.Id == user.Id).Include(x => x.Group).ToListAsync();
            return View(lista);
        }

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Stations.Include(x=>x.Events).Include(x=>x.Drivers).Include(x=>x.Connections).FirstOrDefaultAsync(m => m.Id == id);


            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            var user = _manager.GetUserAsync(HttpContext.User).Result;
            var grupos = _context.Groups.Include(x => x.User).Where(x => x.User.Id == user.Id).ToList();
            ViewData["grupos"] = grupos;

            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GroupId")] Station station)
        {
            ModelState.Remove("User");

            var user = await _manager.GetUserAsync(HttpContext.User);
            station.User = user;


            if (ModelState.IsValid)
            {
                station.Id = Guid.NewGuid();
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _manager.GetUserAsync(HttpContext.User);

            var station = await _context.Stations.Include(x => x.User).Where(x => x.User.Id == user.Id).Include(x=>x.Group).FirstOrDefaultAsync(x=> x.Id == id);

            if (station == null)
            {
                return NotFound();
            }

            var grupos = await _context.Groups.Include(x => x.User).Where(x => x.User.Id == user.Id).ToListAsync();
            ViewData["grupos"] = grupos;


            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,GroupId")] Station station)
        {
            if (id != station.Id)
            {
                return NotFound();
            }
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.Id))
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
            return View(station);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Hardware([FromBody] Station station)
        {
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                try
                {

                    Station obj = _context.Stations
                        .Include(x=>x.Drivers)
                        .Include(x=>x.Connections)
                        .Include(x=>x.Softwares)
                        .Where(x => x.Id == station.Id)
                        .FirstOrDefault();

                    if (obj != null)
                    {

                        foreach (var pr in obj.GetType().GetProperties())
                        {
                            if (pr.CanWrite)
                            {
                                object value = pr.GetValue(station);
                                if (value is Guid)
                                {
                                    Guid aux;
                                    if (Guid.TryParse(value.ToString(), out aux))
                                    {
                                        if (aux != Guid.Empty)
                                        {
                                            pr.SetValue(obj, value);
                                        }
                                    }
                                }
                                else
                                {
                                    if (value != null)
                                        pr.SetValue(obj, value);
                                }
                            }
                        }

                        //obj.Cpu = station.Cpu;
                        //obj.MotherBoard = station.MotherBoard;
                        //obj.Memory = station.Memory;
                        //obj.Drivers = station.Drivers;
                        //obj.Connections = station.Connections;
                        //obj.Softwares = station.Softwares;

                        //_context.Update(obj);

                        obj.LastUpdate = DateTime.Now;

                        _context.InsertOrUpdate<Station>(obj);

                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //return RedirectToAction(nameof(Index));
            }

            return Content("Sucess");

            //return View(station);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _manager.GetUserAsync(HttpContext.User);

            var station = await _context.Stations.Include(x=> x.User).Where(x=>x.User.Id == user.Id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var station = await _context.Stations.FindAsync(id);
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(Guid id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }
    }
}
