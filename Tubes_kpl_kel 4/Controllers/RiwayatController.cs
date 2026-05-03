using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;
using System.Collections.Generic;
using System.Linq;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/riwayatreservasi")]
    public class RiwayatController : ControllerBase
    {
        private readonly StatusReservasi _statusReservasi;

        public RiwayatController()
        {
            _statusReservasi = new StatusReservasi();
        }

        
        [HttpGet]
        public ActionResult<List<DataReservasi>> GetRiwayatReservasi([FromQuery] string namaUser)
        {
            if (string.IsNullOrWhiteSpace(namaUser))
            {
                return BadRequest("Nama user harus disertakan sebagai query string.");
            }

            var daftarReservasi = _statusReservasi.DaftarReservasi;
            var riwayatUser = daftarReservasi
                .Where(r => r.jReservasi.NamaUser.Equals(namaUser, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (riwayatUser.Count == 0)
            {
                return NotFound("Riwayat reservasi tidak ditemukan untuk user tersebut.");
            }

            return Ok(riwayatUser);
        }
    }
}
