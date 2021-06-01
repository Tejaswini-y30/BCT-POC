using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic.Model;

namespace Organic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly OrganicShopContext _context;

        public ShippingController(OrganicShopContext context)
        {
            _context = context;
        }

        // GET: api/Shipping
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShippings()
        {
            return await _context.Shippings.ToListAsync();
        }

        // GET: api/Shipping/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShipping(int id)
        {
            var shipping = await _context.Shippings.FindAsync(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return shipping;
        }

        // PUT: api/Shipping/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping(int id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shipping
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            _context.Shippings.Add(shipping);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShippingExists(shipping.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShipping", new { id = shipping.Id }, shipping);
        }

        // DELETE: api/Shipping/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            var shipping = await _context.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.Shippings.Remove(shipping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShippingExists(int id)
        {
            return _context.Shippings.Any(e => e.Id == id);
        }
    }
}
