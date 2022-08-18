using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LiteDBProject.Data;
using LiteDBProject.Data.SQLite;

namespace LiteDBProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly PremixContext _context;

        public DevelopersController(PremixContext context)
        {
            _context = context;
        }

        // GET: api/Developers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> Getdevelopers()
        {
          if (_context.Developers == null)
          {
              return NotFound();
          }
            return await _context.Developers.ToListAsync();
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
          if (_context.Developers == null)
          {
              return NotFound();
          }
            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return developer;
        }

        // PUT: api/Developers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloper(int id, Developer developer)
        {
            //if (id != developer.DeveloperId)
            //{
            //    return BadRequest();
            //}
            Developer d = new Developer()
            {
                DeveloperId = id,
                Name = developer.Name,
                Country = developer.Country
            };
            //_context.Entry(developer).State = EntityState.Modified;
            _context.Developers.Update(d);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Developers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(Developer developer)
        {
          if (_context.Developers == null)
          {
              return Problem("Entity set 'PremixContext.developers'  is null.");
          }
            _context.Developers.Add(developer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeveloperExists(developer.DeveloperId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeveloper", new { id = developer.DeveloperId }, developer);
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            if (_context.Developers == null)
            {
                return NotFound();
            }
            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeveloperExists(int id)
        {
            return (_context.Developers?.Any(e => e.DeveloperId == id)).GetValueOrDefault();
        }
    }
}
