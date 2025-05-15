using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PembatalanController : ControllerBase
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");

        [HttpDelete]
        public IActionResult BatalkanReservasi(
            [FromQuery] string tempat,
            [FromQuery] string ruangan,
            [FromQuery] string tanggal,
            [FromQuery] string jamMulai,
            [FromQuery] string alasan)
        {
            if (string.IsNullOrWhiteSpace(alasan))
                return BadRequest("Alasan pembatalan diperlukan.");

            if (!System.IO.File.Exists(_filePath))
                return NotFound("Data reservasi tidak ditemukan.");

            var json = System.IO.File.ReadAllText(_filePath);
            var rootNode = JsonDocument.Parse(json).RootElement;
            var reservasiList = JsonSerializer.Deserialize<List<ReservasiItem>>(rootNode.GetProperty("Reservasi").ToString());

            var reservasi = reservasiList?
            .FirstOrDefault(r =>
                r.Tempat.Equals(tempat, StringComparison.OrdinalIgnoreCase) &&
                r.Ruangan.Equals(ruangan, StringComparison.OrdinalIgnoreCase) &&
                r.Jadwal != null &&
                r.Jadwal.Tanggal == tanggal &&
                r.Jadwal.Mulai == jamMulai &&
                r.Status == "Aktif");

            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan atau sudah dibatalkan.");

            if (!Validators.Validasi.ValidasiPembatalan($"{tempat}-{ruangan}", alasan))
                return BadRequest("Alasan pembatalan tidak valid.");

            reservasi.Status = "Dibatalkan";
            reservasi.AlasanPembatalan = alasan;

            var kelasJson = JsonNode.Parse(json);
            kelasJson["Reservasi"] = JsonSerializer.SerializeToNode(reservasiList);

            System.IO.File.WriteAllText(_filePath, kelasJson.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

            return Ok("Reservasi berhasil dibatalkan.");
        }
    }
}