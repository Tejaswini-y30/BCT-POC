using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom.Model;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly POCecommercesiteContext _context;

        public CartController(POCecommercesiteContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCart>>> GetTblCarts()
        {
            return await _context.TblCarts.ToListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TblCart>>> GetTblCart(string id)
        {
            var tblCart =await _context.TblCarts.Where(p => p.CartId == id ).ToListAsync();

            if (!tblCart.Any())
            {
                return NotFound();
            }

            return tblCart;
        }

        [HttpGet("Purchased/{purchased}")]
        public async Task<ActionResult<IEnumerable<TblCart>>> GetTblProductpurchased(string purchased)
        {
            
            var Product = await _context.TblCarts.Where(p => p.Purchased == purchased ).ToListAsync();

            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }

        [HttpGet("Usercart/{userid}")]
        public async Task<ActionResult<IEnumerable<TblCart>>> GetTblUsercart(string userid)
        {
            
            var usercart = await _context.TblCarts.Where(p => p.UserId == userid ).ToListAsync();

            if (!usercart.Any())
            {
                return NotFound();
            }

            return usercart;
        }
        // PUT: api/Cart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCart(string id, TblCart tblCart)
        {
            if (id != tblCart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(tblCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCartExists(id))
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

        // POST: api/Cart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCart>> PostTblCart(TblCart tblCart)
        {
            _context.TblCarts.Add(tblCart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCartExists(tblCart.CartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCart", new { id = tblCart.CartId }, tblCart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCart(string id)
        {
            var tblCart = await _context.TblCarts.FindAsync(id);
            if (tblCart == null)
            {
                return NotFound();
            }

            _context.TblCarts.Remove(tblCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCartExists(string id)
        {
            return _context.TblCarts.Any(e => e.CartId == id);
        }
    }
}
