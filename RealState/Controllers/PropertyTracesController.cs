using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealState.Entities;
using RealState.Services;

namespace RealState.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTracesController : ControllerBase
    {
        private readonly RealStateDbContext _context;

        public PropertyTracesController(RealStateDbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyTraces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyTrace>>> GetPropertyTrace()
        {
            return await _context.PropertyTrace.ToListAsync();
        }

        // GET: api/PropertyTraces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyTrace>> GetPropertyTrace(int id)
        {
            var propertyTrace = await _context.PropertyTrace.FindAsync(id);

            if (propertyTrace == null)
            {
                return NotFound();
            }

            return propertyTrace;
        }

        // PUT: api/PropertyTraces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyTrace(int id, PropertyTrace propertyTrace)
        {
            if (id != propertyTrace.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyTrace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyTraceExists(id))
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

        // POST: api/PropertyTraces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyTrace>> PostPropertyTrace(PropertyTrace propertyTrace)
        {
            _context.PropertyTrace.Add(propertyTrace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyTrace", new { id = propertyTrace.Id }, propertyTrace);
        }

        // DELETE: api/PropertyTraces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyTrace(int id)
        {
            var propertyTrace = await _context.PropertyTrace.FindAsync(id);
            if (propertyTrace == null)
            {
                return NotFound();
            }

            _context.PropertyTrace.Remove(propertyTrace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyTraceExists(int id)
        {
            return _context.PropertyTrace.Any(e => e.Id == id);
        }
    }
}
