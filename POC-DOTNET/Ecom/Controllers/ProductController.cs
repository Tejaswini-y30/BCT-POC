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
    public class ProductController : ControllerBase
    {
        private readonly POCecommercesiteContext _context;

        public ProductController(POCecommercesiteContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProducts()
        {
            return await _context.TblProducts.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProduct>> GetTblProduct(string id)
        {
            var tblProduct = await _context.TblProducts.FindAsync(id);

            if (tblProduct == null)
            {
                return NotFound();
            }

            return tblProduct;
        }

        [HttpGet("maxcost/{Cost}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProducts(decimal Cost)
        {
            
            var Product = await _context.TblProducts.Where(u => u.Cost <= Cost).ToListAsync();
            
            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }

        [HttpGet("mincost/{Cost}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProductmin(decimal Cost)
        {
            
            var Product = await _context.TblProducts.Where(u => u.Cost >= Cost).ToListAsync();
            
            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }
        [HttpGet("minmaxfilter/{minCost}/{maxCost}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProductminmax(decimal minCost,decimal maxCost)
        {
            
            var Product = await _context.TblProducts.Where(u => u.Cost <= maxCost & u.Cost >=minCost).ToListAsync();
            
            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }
        [HttpGet("Catergoryfilter/{categoryId}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProductcatergoryfilter(string categoryId)
        {
            
            var Product = await _context.TblProducts.Where(p => p.CategoryId == categoryId ).ToListAsync();

            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }

        [HttpGet("Colorfilter/{color}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProductcolorfilter(string color)
        {
            
            var Product = await _context.TblProducts.Where(p => p.ProductColor == color ).ToListAsync();

            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }

        [HttpGet("sizefilter/{size}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProductsizefilter(string size)
        {
            
            var Product = await _context.TblProducts.Where(p => p.ProductSize == size ).ToListAsync();

            if (!Product.Any())
            {
                return NotFound();
            }

            return Product;
        }
        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProduct(string id, TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(tblProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProduct>> PostTblProductDTO([FromForm]TblProduct tblProduct)
        {
            _context.TblProducts.Add(tblProduct);
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblProductExists(tblProduct.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblProduct", new { id = tblProduct.ProductId }, tblProduct);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProduct(string id)
        {
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            _context.TblProducts.Remove(tblProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProductExists(string id)
        {
            return _context.TblProducts.Any(e => e.ProductId == id);
        }
    }
}

