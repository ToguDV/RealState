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
    public class PropertyItemsController : ControllerBase
    {
        private readonly RealStateDbContext _context;

        public PropertyItemsController(RealStateDbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyItem>>> GetPropertyItems()
        {
            return await _context.PropertyItems.ToListAsync();
        }

        // GET: api/PropertyItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyItem>> GetPropertyItem(int id)
        {
            var propertyItem = await _context.PropertyItems.FindAsync(id);

            if (propertyItem == null)
            {
                return NotFound();
            }

            return propertyItem;
        }

        // PUT: api/PropertyItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyItem(int id, PropertyItem propertyItem)
        {
            if (id != propertyItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyItemExists(id))
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

        // POST: api/PropertyItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyItem>> PostPropertyItem(PropertyItem propertyItem)
        {
            _context.PropertyItems.Add(propertyItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyItem", new { id = propertyItem.Id }, propertyItem);
        }

        // DELETE: api/PropertyItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyItem(int id)
        {
            var propertyItem = await _context.PropertyItems.FindAsync(id);
            if (propertyItem == null)
            {
                return NotFound();
            }

            _context.PropertyItems.Remove(propertyItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyItemExists(int id)
        {
            return _context.PropertyItems.Any(e => e.Id == id);
        }
    }
}
