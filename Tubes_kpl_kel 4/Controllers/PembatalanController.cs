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

        [HttpDelete("{kodeKelas}")]
        public IActionResult BatalkanReservasi(string kodeKelas, [FromQuery] string alasan)
        {
            if (string.IsNullOrWhiteSpace(alasan))
                return BadRequest("Alasan pembatalan diperlukan.");

            if (!System.IO.File.Exists(_filePath))
                return NotFound("Data reservasi tidak ditemukan.");

            var json = System.IO.File.ReadAllText(_filePath);
            var rootNode = JsonDocument.Parse(json).RootElement;

            var reservasiList = JsonSerializer.Deserialize<List<ReservasiItem>>(rootNode.GetProperty("Reservasi").ToString());

            var reservasi = reservasiList?.FirstOrDefault(r =>
                $"{r.Tempat}-{r.Ruangan}".Replace(" ", "").Equals(kodeKelas.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)
                && r.Status == "Aktif"
            );

            if (reservasi == null)
                return NotFound("Reservasi dengan kode tersebut tidak ditemukan atau sudah dibatalkan.");

            var pembatalan = new PembatalanReservasi(kodeKelas);
            if (!pembatalan.Batalkan(alasan))
                return BadRequest("Pembatalan gagal.");

            reservasi.Status = "Dibatalkan";
            reservasi.AlasanPembatalan = alasan;

            var kelasJson = JsonNode.Parse(json);
            kelasJson["Reservasi"] = JsonSerializer.SerializeToNode(reservasiList);

            System.IO.File.WriteAllText(_filePath, kelasJson.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));

            return Ok("Reservasi berhasil dibatalkan.");
        }
    }
}