using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;



namespace Tubes_kpl_kel_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] Tubes_kpl_kel_4.Models.RegisterRequest request)
        {
            return Ok($"Akun untuk {request.Nama} berhasil dibuat.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Tubes_kpl_kel_4.Models.LoginRequest request)
        {
            if (request.Password.Length >= 6)
            {
                return Ok($"Login berhasil. Selamat datang, {request.Username}!");
            }

            return BadRequest("Login gagal. Password minimal 6 karakter.");
        }
    }
}


