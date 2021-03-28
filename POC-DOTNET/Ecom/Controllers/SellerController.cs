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
    public class SellerController : ControllerBase
    {
        private readonly POCecommercesiteContext _context;

        public SellerController(POCecommercesiteContext context)
        {
            _context = context;
        }

        // GET: api/Seller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSeller>>> GetTblSellers()
        {
            return await _context.TblSellers.ToListAsync();
        }

        // GET: api/Seller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSeller>> GetTblSeller(string id)
        {
            var tblSeller = await _context.TblSellers.FindAsync(id);

            if (tblSeller == null)
            {
                return NotFound();
            }

            return tblSeller;
        }


         [HttpGet("GetSellerDetails/{Id}")]
        public async Task<ActionResult<TblSeller>> GetPublisherDetails(string id)
        {
            
            //Explicit Loading
            var seller = await _context.TblSellers.SingleAsync(TblSeller => TblSeller.SellerId == id);

            _context.Entry(seller)
                    .Collection(TblSeller => TblSeller.TblCategories)
                    .Query()
                    .Load();

            _context.Entry(seller)
                    .Collection(TblSeller => TblSeller.TblProducts)
                    .Query()
                    .Load();

            

            if (seller == null)
            {
                return NotFound();
            }

            return seller;
        }






        // PUT: api/Seller/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSeller(string id, TblSeller tblSeller)
        {
            if (id != tblSeller.SellerId)
            {
                return BadRequest();
            }

            _context.Entry(tblSeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSellerExists(id))
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

        



        // POST: api/Seller

        [HttpPost]
        public async Task<ActionResult<TblSeller>> PostTblSeller(TblSeller tblSeller)
        {
            _context.TblSellers.Add(tblSeller);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblSellerExists(tblSeller.SellerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblSeller", new { id = tblSeller.SellerId }, tblSeller);
        }

        // DELETE: api/Seller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSeller(string id)
        {
            var tblSeller = await _context.TblSellers.FindAsync(id);
            if (tblSeller == null)
            {
                return NotFound();
            }

            _context.TblSellers.Remove(tblSeller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSellerExists(string id)
        {
            return _context.TblSellers.Any(e => e.SellerId == id);
        }
    }
}
