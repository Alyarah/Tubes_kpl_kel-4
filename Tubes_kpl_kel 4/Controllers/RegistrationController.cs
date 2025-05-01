using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        [HttpPost("mahasiswa")]
        public IActionResult RegisterMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            var form = new RegistrationForm<Mahasiswa> { UserData = mahasiswa };
            return Ok(form.Register());
        }

        [HttpPost("dosen")]
        public IActionResult RegisterDosen([FromBody] Dosen dosen)
        {
            var form = new RegistrationForm<Dosen> { UserData = dosen };
            return Ok(form.Register());
        }

        [HttpPost("staf")]
        public IActionResult RegisterStaf([FromBody] Staf staf)
        {
            var form = new RegistrationForm<Staf> { UserData = staf };
            return Ok(form.Register());
        }
    }
}

