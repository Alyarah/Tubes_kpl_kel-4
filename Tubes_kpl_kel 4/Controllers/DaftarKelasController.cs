using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DaftarKelasController : ControllerBase
    {
        private readonly DaftarKelas _daftarKelas;

        public DaftarKelasController()
        {
            _daftarKelas = new DaftarKelas("config.json");
        }

        [HttpGet]
        public IActionResult GetDaftarKelas()
        {
            return Ok(_daftarKelas.ListKelas);
        }
    }
}
