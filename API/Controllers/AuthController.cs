using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.API.Data;
using ShoeStore.API.Models;
using ShoeStore.Shared.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ShoeStoreContext _context;

        public AuthController(ShoeStoreContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.UserName,
                Email = registerDto.Email,
                Password = registerDto.Password 
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == loginDto.UserName && u.Password == loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Thực hiện các bước đăng nhập (ví dụ: tạo token JWT)

            return Ok();
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            // Thực hiện các bước đăng xuất (ví dụ: xóa token JWT)

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, RegisterDto registerDto)
        {
            if (id != registerDto.UserName)
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Username = registerDto.UserName;
            user.Email = registerDto.Email;
            user.Password = registerDto.Password; 

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

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
    }
}