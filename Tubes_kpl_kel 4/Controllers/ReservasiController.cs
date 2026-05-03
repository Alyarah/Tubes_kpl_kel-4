using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasiController : ControllerBase
    {
        private readonly string _filePath;
        private readonly DaftarKelas _daftarKelas;
        private readonly StatusReservasi _statusReservasi;

        public ReservasiController()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            _daftarKelas = new DaftarKelas(_filePath);
            _statusReservasi = new StatusReservasi();

        }

        [HttpPost]
        public IActionResult PostReservasi([FromBody] ReservasiModel request)
        {
            var user = new User { Nama = request.NamaUser };

            var reservasiService = new ReservasiRuangan<User, Jadwal, DataReservasi>(
                user,
                _daftarKelas.ListKelas,
                _statusReservasi.DaftarReservasi,
                _daftarKelas,
                _statusReservasi
            );

            string hasil = reservasiService.LakukanReservasi(
                request.Tempat,
                request.Ruangan,
                request.Kapasitas,
                request.Tanggal,
                request.JamMulai,
                request.JamSelesai
            );

            if (hasil.StartsWith("Sukses"))
                return Ok(new { message = hasil });
            else
                return BadRequest(new { error = hasil });
        }
    }
}