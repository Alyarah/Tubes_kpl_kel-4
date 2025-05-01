using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var registrasi = new Registrasi<User>
            {
                Nama = request.Nama,
                Email = request.Email,
                Password = request.Password
            };

            var hasil = registrasi.Register();

            if (hasil.StartsWith("Registrasi berhasil"))
            {
                return Ok(hasil);
            }
            else
            {
                return BadRequest(hasil);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var login = new Login();
            var hasil = login.LoginUser(request.Nama, request.Email, request.Password);

            if (login.Status == StatusLogin.Berhasil)
            {
                return Ok(hasil);
            }
            else
            {
                return BadRequest(hasil);
            }
        }
    }
}
