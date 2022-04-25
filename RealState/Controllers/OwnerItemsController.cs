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
    public class OwnerItemsController : ControllerBase
    {
        private readonly RealStateDbContext _context;

        public OwnerItemsController(RealStateDbContext context)
        {
            _context = context;
        }

        // GET: api/OwnerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerItem>>> GetOwnerItem()
        {
            return await _context.OwnerItem.ToListAsync();
        }

        // GET: api/OwnerItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerItem>> GetOwnerItem(int id)
        {
            var ownerItem = await _context.OwnerItem.FindAsync(id);

            if (ownerItem == null)
            {
                return NotFound();
            }

            return ownerItem;
        }

        // PUT: api/OwnerItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnerItem(int id, OwnerItem ownerItem)
        {
            if (id != ownerItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(ownerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerItemExists(id))
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

        // POST: api/OwnerItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OwnerItem>> PostOwnerItem(OwnerItem ownerItem)
        {
            _context.OwnerItem.Add(ownerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwnerItem", new { id = ownerItem.Id }, ownerItem);
        }

        // DELETE: api/OwnerItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerItem(int id)
        {
            var ownerItem = await _context.OwnerItem.FindAsync(id);
            if (ownerItem == null)
            {
                return NotFound();
            }

            _context.OwnerItem.Remove(ownerItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerItemExists(int id)
        {
            return _context.OwnerItem.Any(e => e.Id == id);
        }
    }
}
