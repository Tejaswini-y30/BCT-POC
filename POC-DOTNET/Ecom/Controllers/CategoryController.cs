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
    public class CategoryController : ControllerBase
    {
        private readonly POCecommercesiteContext _context;

        public CategoryController(POCecommercesiteContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategory>>> GetTblCategories()
        {
            return await _context.TblCategories.ToListAsync();
        }

        [HttpGet("GetcategoryDetails/{Id}")]
        public async Task<ActionResult<TblCategory>> GetcategoryDetails(string id)
        {
            
            //Explicit Loading
            var category = await _context.TblCategories.SingleAsync(TblCategory => TblCategory.CategoryId== id);

            _context.Entry(category)
                    .Collection(TblCategories => TblCategories.TblProducts)
                    .Query()
                    .Load();

            _context.Entry(category)
                    .Collection(TblSeller => TblSeller.TblProducts)
                    .Query()
                    .Load();

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCategory>> GetTblCategory(string id)
        {
            var tblCategory = await _context.TblCategories.FindAsync(id);

            if (tblCategory == null)
            {
                return NotFound();
            }

            return tblCategory;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCategory(string id, TblCategory tblCategory)
        {
            if (id != tblCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(tblCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCategoryExists(id))
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

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCategory>> PostTblCategory(TblCategory tblCategory)
        {
            _context.TblCategories.Add(tblCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCategoryExists(tblCategory.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCategory", new { id = tblCategory.CategoryId }, tblCategory);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCategory(string id)
        {
            var tblCategory = await _context.TblCategories.FindAsync(id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            _context.TblCategories.Remove(tblCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCategoryExists(string id)
        {
            return _context.TblCategories.Any(e => e.CategoryId == id);
        }
    }
}
