using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic.Model;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens;
namespace Organic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OrganicShopContext _context;
        private readonly JWTSettings _jwtsettings;

        public UserController(OrganicShopContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        [HttpGet("LoginGet/{Email}/{Password}")]
        public async Task<ActionResult<User>> LoginGet(string Email ,String Password)
        {
            var user = await _context.Users
                                        .Where(u => u.Email == Email
                                                && u.Password == Password).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            Console.WriteLine(user);
            return user;
        }
        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Register")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        /*[HttpPost("Login")]
        public async Task<ActionResult<IList<User>>> Login(User user)
        {
            Console.WriteLine("loginhere");
            user = await _context.Users
                                        .Where(u => u.Email == user.Email
                                                && u.Password == user.Password).FirstOrDefaultAsync();

           if (user == null)
            {
                return NotFound();
            }
            

            //sign your token here here..
            return user;
        }*/


        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] User user)
        {
            user = await _context.Users
                                        .Where(u => u.Email == user.Email
                                                && u.Password == user.Password).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            //sign your token here here..
           var tokenHandler =new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject =new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires =DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token =tokenHandler.CreateToken(tokenDescriptor);
            user.Token=tokenHandler.WriteToken(token);

            return user;
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
