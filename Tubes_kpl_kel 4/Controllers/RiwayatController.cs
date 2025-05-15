using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiwayatController : ControllerBase
    {
        // Sementara pakai data dummy (bisa diganti dengan database atau file JSON nantinya)
        private static readonly List<RiwayatReservasiItem> _riwayat = new List<RiwayatReservasiItem>
        {
            new RiwayatReservasiItem
            {
                DetailJadwal = new Jadwal
                {
                    Tempat = "Gedung B", Ruangan = "R.204", Kapasitas = 35,
                    Hari = "Rabu", Mulai = "13:00", Selesai = "15:00"
                },
                Tempat = "Gedung B",
                Ruangan = "R.204",
                Kapasitas = 35,
                Status = "Berhasil",
                AlasanPembatalan = null
            },
            new RiwayatReservasiItem
            {
                DetailJadwal = new Jadwal
                {
                    Tempat = "Gedung A", Ruangan = "R.101", Kapasitas = 40,
                    Hari = "Selasa", Mulai = "10:00", Selesai = "12:00"
                },
                Tempat = "Gedung A",
                Ruangan = "R.101",
                Kapasitas = 40,
                Status = "Dibatalkan",
                AlasanPembatalan = "Bentrok dengan mata kuliah lain"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<RiwayatReservasiItem>> GetRiwayatReservasi()
        {
            return Ok(_riwayat);
        }
    }
}