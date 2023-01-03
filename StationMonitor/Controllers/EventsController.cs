using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationMonitor.Data;
using StationMonitor.Entidades;

namespace StationMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEventos()
        {
            return _context.Events;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvent([FromRoute] Guid id, [FromBody] Event @event)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != @event.StationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(@event).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] IEnumerable<Event> eventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Stations.Any(x => x.Id == eventos.FirstOrDefault().StationId))
            {
                int? maxSeq = _context.Events.Where(x => x.StationId == eventos.FirstOrDefault().StationId)?.Max(x => x.Sequence);

                if (!maxSeq.HasValue)
                    maxSeq = 0;


                foreach (Event evento in eventos)
                {
                    maxSeq++;
                    evento.Sequence = maxSeq;
                    _context.Events.Add(evento);
                }
                await _context.SaveChangesAsync();
            }

            return Content("Sucess");

            //return CreatedAtAction("GetEvent", new { id = eventos.StationId }, eventos);
        }

        // DELETE: api/Events/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEvent([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var @event = await _context.Eventos.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Eventos.Remove(@event);
        //    await _context.SaveChangesAsync();

        //    return Ok(@event);
        //}

        //private bool EventExists(Guid id)
        //{
        //    return _context.Eventos.Any(e => e.StationId == id);
        //}
    }
}