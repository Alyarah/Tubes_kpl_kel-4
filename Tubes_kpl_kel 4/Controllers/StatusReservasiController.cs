using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusReservasiController : ControllerBase
    {
        private readonly StatusReservasi _statusReservasi;

        public StatusReservasiController()
        {
            _statusReservasi = new StatusReservasi();
        }

        [HttpGet]
        public IActionResult GetAllReservasi()
        {
            return Ok(_statusReservasi.DaftarReservasi);
        }

        [HttpGet("availability")]
        public IActionResult GetAvailability([FromQuery] string tanggal, [FromQuery] string mulai, [FromQuery] string selesai)
        {
            var semuaRuangan = new List<(string Tempat, string Ruangan)>
            {
                ("Gedung A", "R.01"), ("Gedung A", "R.02"), ("Gedung A", "R.03"),
                ("Gedung A", "R.04"), ("Gedung A", "R.05"),
                ("Gedung B", "R.01"), ("Gedung B", "R.02"), ("Gedung B", "R.03"),
                ("Gedung B", "R.04"), ("Gedung B", "R.05"),
                ("Lab", "01"), ("Lab", "02")
            };

            var hasil = semuaRuangan.Select(ruangan =>
            {
                bool dipesan = _statusReservasi.DaftarReservasi.Any(r =>
                    r.Tempat == ruangan.Tempat &&
                    r.Ruangan == ruangan.Ruangan &&
                    r.jReservasi.Tanggal == tanggal
                );

                return new
                {
                    ruangan.Tempat,
                    ruangan.Ruangan,
                    Status = dipesan ? "Sudah Dipesan" : "Tersedia"
                };
            });

            return Ok(hasil);
        }
    }
}
