using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasiController : ControllerBase
    {
        // Simulasi data jadwal tetap diambil dari DaftarKelas
        private static DaftarKelas _daftarKelas = new DaftarKelas(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json")
        );

        private static List<Jadwal> _jadwalList = _daftarKelas.ListKelas;

        // Simulasi database reservasi, awalnya kosong
        private static List<DataReservasi> _reservasiList = new();

        // Simulasi user login (ganti kalau ada autentikasi)
        private static User _currentUser = new User { Nama = "Sheila" };

        public class ReservasiRequest
        {
            public string Tempat { get; set; }
            public string Ruangan { get; set; }
            public int Kapasitas { get; set; }
            public string Tanggal { get; set; }
            public string JamMulai { get; set; }
            public string JamSelesai { get; set; }
        }

        [HttpPost]
        public IActionResult PostReservasi([FromBody] ReservasiRequest request)
        {
            // Buat instance service reservasi
            var reservasiService = new ReservasiRuangan(_currentUser, _jadwalList, _reservasiList, _daftarKelas);

            // Panggil method untuk melakukan reservasi
            string hasil = reservasiService.LakukanReservasi(
                request.Tempat,
                request.Ruangan,
                request.Kapasitas,
                request.Tanggal,
                request.JamMulai,
                request.JamSelesai
            );

            if (hasil.StartsWith("Gagal"))
            {
                return BadRequest(new { message = hasil });
            }

            return Ok(new { message = hasil });
        }
    }
}


