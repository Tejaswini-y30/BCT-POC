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
    public class ShippingDetailController : ControllerBase
    {
        private readonly POCecommercesiteContext _context;

        public ShippingDetailController(POCecommercesiteContext context)
        {
            _context = context;
        }

        // GET: api/ShippingDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblShippingDetail>>> GetTblShippingDetails()
        {
            return await _context.TblShippingDetails.ToListAsync();
        }


        [HttpGet("Userdetails/{userid}")]
        public async Task<ActionResult<IEnumerable<TblShippingDetail>>> GetTblUserdetails(string userid)
        {
            
            var userdetails = await _context.TblShippingDetails.Where(p => p.UserId== userid ).ToListAsync();

            if (!userdetails.Any())
            {
                return NotFound();
            }

            return userdetails;
        }
        // GET: api/ShippingDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblShippingDetail>> GetTblShippingDetail(string id)
        {
            var tblShippingDetail = await _context.TblShippingDetails.FindAsync(id);

            if (tblShippingDetail == null)
            {
                return NotFound();
            }

            return tblShippingDetail;
        }

        // PUT: api/ShippingDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblShippingDetail(string id, TblShippingDetail tblShippingDetail)
        {
            if (id != tblShippingDetail.ShippingDetailId)
            {
                return BadRequest();
            }

            _context.Entry(tblShippingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblShippingDetailExists(id))
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

        // POST: api/ShippingDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblShippingDetail>> PostTblShippingDetail(TblShippingDetail tblShippingDetail)
        {
            _context.TblShippingDetails.Add(tblShippingDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblShippingDetailExists(tblShippingDetail.ShippingDetailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblShippingDetail", new { id = tblShippingDetail.ShippingDetailId }, tblShippingDetail);
        }

        // DELETE: api/ShippingDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblShippingDetail(string id)
        {
            var tblShippingDetail = await _context.TblShippingDetails.FindAsync(id);
            if (tblShippingDetail == null)
            {
                return NotFound();
            }

            _context.TblShippingDetails.Remove(tblShippingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblShippingDetailExists(string id)
        {
            return _context.TblShippingDetails.Any(e => e.ShippingDetailId == id);
        }
    }
}
