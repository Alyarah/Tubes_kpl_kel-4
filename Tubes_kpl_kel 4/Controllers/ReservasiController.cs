using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;


namespace Tubes_kpl_kel_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
      
        public class ReservasiController : ControllerBase
        {
            [HttpPost]
            public IActionResult BuatReservasi([FromBody] ReservasiRequest request)
            {
                return Ok($"Reservasi ruang {request.NamaRuangan} berhasil untuk {request.Tanggal}");
            }

            [HttpDelete("{id}")]
            public IActionResult BatalkanReservasi(int id)
            {
                return Ok($"Reservasi dengan ID {id} berhasil dibatalkan.");
            }

            [HttpGet("riwayat/{userId}")]
            public IActionResult Riwayat(int userId)
            {
                return Ok($"Menampilkan riwayat reservasi untuk user ID {userId}");
            }
        }
}


