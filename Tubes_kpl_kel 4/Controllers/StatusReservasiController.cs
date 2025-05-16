using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/statusreservasi")]
    public class StatusReservasiController : ControllerBase
    {
        private readonly StatusReservasi _statusReservasi;

        public StatusReservasiController()
        {
            _statusReservasi = new StatusReservasi();
        }

       
        [HttpGet]
        public ActionResult<List<DataReservasi>> GetStatusReservasi()
        {
            if (_statusReservasi.DaftarReservasi == null || !_statusReservasi.DaftarReservasi.Any())
            {
                return NotFound("Tidak ada data reservasi ditemukannnnnnnnn.");
            }

            return Ok(_statusReservasi.DaftarReservasi);
        }

        
        [HttpGet("filter")]
        public ActionResult<List<DataReservasi>> GetFilteredStatus([FromQuery] string? tanggal)
        {
            var list = _statusReservasi.DaftarReservasi;

            if (!string.IsNullOrEmpty(tanggal))
            {
                list = list.Where(r => r.jReservasi.Tanggal == tanggal).ToList();
            }

            if (list == null || !list.Any())
            {
                return NotFound("Tidak ada data reservasi sesuai filter.");
            }

            return Ok(list);
        }
    }
}
