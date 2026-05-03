using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PembatalanReservasiController : ControllerBase
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");

        [HttpDelete]
        public IActionResult BatalkanReservasi([FromBody] RequestPembatalan dto)
        {
            if (!System.IO.File.Exists(filePath))
                return NotFound("File reservasi tidak ditemukan.");

            try
            {
                // Baca data dari file JSON
                var jsonData = System.IO.File.ReadAllText(filePath);
                var node = JsonNode.Parse(jsonData);
                var reservasiArray = node?["Reservasi"];
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                var dataList = reservasiArray?.Deserialize<List<DataReservasi>>(options) ?? new List<DataReservasi>();

                // Lakukan pembatalan
                var pembatalan = new PembatalanReservasi(dataList);
                bool sukses = pembatalan.Batalkan(dto.Tempat, dto.Ruangan, dto.Tanggal, dto.Mulai, dto.Alasan);

                if (!sukses)
                    return BadRequest("Pembatalan gagal. Periksa data input.");

                // Tulis ulang data ke file JSON
                var newJson = new JsonObject
                {
                    ["Reservasi"] = JsonSerializer.SerializeToNode(dataList, options)
                };
                System.IO.File.WriteAllText(filePath, newJson.ToJsonString(options));

                return Ok("Reservasi berhasil dibatalkan.");
            }
            catch
            {
                return StatusCode(500, "Terjadi kesalahan saat memproses pembatalan.");
            }
        }
    }

    public class RequestPembatalan
    {
        public string Tempat { get; set; }
        public string Ruangan { get; set; }
        public string Tanggal { get; set; } // Format: yyyy-MM-dd
        public string Mulai { get; set; }   // Format: HH:mm
        public string Alasan { get; set; }
    }
}
