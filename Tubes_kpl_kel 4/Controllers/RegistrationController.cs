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
            var form = new FormRegistration<Mahasiswa> { UserData = mahasiswa };
            return Ok(form.Register());
        }

        [HttpPost("dosen")]
        public IActionResult RegisterDosen([FromBody] Dosen dosen)
        {
            var form = new FormRegistration<Dosen> { UserData = dosen };
            return Ok(form.Register());
        }

        [HttpPost("staf")]
        public IActionResult RegisterStaf([FromBody] Staf staf)
        {
            var form = new FormRegistration<Staf> { UserData = staf };
            return Ok(form.Register());
        }
    }
}
