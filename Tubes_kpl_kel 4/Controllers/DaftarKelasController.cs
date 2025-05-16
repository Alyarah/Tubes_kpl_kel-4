using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;
using System.IO;
using System;
using System.Collections.Generic;

namespace Tubes_kpl_kel_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DaftarKelasController : ControllerBase
    {
        private readonly DaftarKelas _daftarKelas;

        public DaftarKelasController()
        {
            
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            _daftarKelas = new DaftarKelas(filePath);
        }

        [HttpGet]
        public IActionResult GetDaftarKelas()
        {
            return Ok(_daftarKelas.ListKelas);
        }
    }
}
