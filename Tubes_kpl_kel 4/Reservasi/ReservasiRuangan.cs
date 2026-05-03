using System.Globalization;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

// Kelas generic untuk melakukan reservasi ruangan
public class ReservasiRuangan<TUser, TJadwal, TReservasi>
    where TUser : User
    where TJadwal : Jadwal
    where TReservasi : DataReservasi, new()
{
    private TUser _user;                            // Pengguna yang melakukan reservasi
    private List<TJadwal> _jadwalList;              // Daftar jadwal tetap yang sudah ada
    private List<TReservasi> _reservasiList;        // Daftar reservasi yang sudah dilakukan
    private DaftarKelas _daftarKelas;               // Data daftar kelas dari file
    private StatusReservasi _statusReservasi;       // Objek untuk menyimpan dan memproses status reservasi

    // Konstruktor untuk mengisi properti saat pembuatan objek
    public ReservasiRuangan(
        TUser user,
        List<TJadwal> jadwalList,
        List<TReservasi> reservasiList,
        DaftarKelas daftarKelas,
        StatusReservasi statusReservasi)
    {
        _user = user;
        _jadwalList = jadwalList;
        _reservasiList = reservasiList;
        _daftarKelas = daftarKelas;
        _statusReservasi = statusReservasi;
    }

    // Method utama untuk melakukan reservasi
    public string LakukanReservasi(string tempat, string ruangan, int kapasitas, string tanggal, string jamMulai, string jamSelesai)
    {
        try
        {
            // Ubah string tanggal menjadi format DateTime
            DateTime tanggalReservasi = DateTime.Parse(tanggal);

            // Ambil nama hari dalam Bahasa Indonesia (Senin, Selasa, dst.)
            string hariDariTanggal = tanggalReservasi.ToString("dddd", new CultureInfo("id-ID"));

            // Cek apakah jadwal tetap bentrok
            foreach (var jadwal in _jadwalList)
            {
                if (jadwal.Tempat == tempat && jadwal.Ruangan == ruangan && jadwal.Hari.Equals(hariDariTanggal, StringComparison.OrdinalIgnoreCase))
                {
                    if (jamMulai.CompareTo(jadwal.Selesai) < 0 && jamSelesai.CompareTo(jadwal.Mulai) > 0)
                    {
                        return $"Gagal: Jadwal tetap di {tempat} {ruangan} bentrok dengan waktu {jadwal.Mulai}-{jadwal.Selesai}.";
                    }
                }
            }

            // Cek apakah sudah ada reservasi di waktu yang sama
            foreach (var reservasi in _reservasiList)
            {
                if (reservasi.Tempat == tempat && reservasi.Ruangan == ruangan && reservasi.jReservasi.Tanggal == tanggal)
                {
                    if (jamMulai.CompareTo(reservasi.jReservasi.Selesai) < 0 && jamSelesai.CompareTo(reservasi.jReservasi.Mulai) > 0)
                    {
                        return $"Gagal: Sudah dipesan oleh {reservasi.jReservasi.NamaUser} dari {reservasi.jReservasi.Mulai} sampai {reservasi.jReservasi.Selesai}.";
                    }
                }
            }

            // Buat objek jadwal reservasi baru
            JadwalReservasi jadwalReservasiBaru = new JadwalReservasi
            {
                NamaUser = _user.Nama,
                Tanggal = tanggal,
                Mulai = jamMulai,
                Selesai = jamSelesai
            };

            // Buat data reservasi baru
            TReservasi dataBaru = new TReservasi
            {
                Tempat = tempat,
                Ruangan = ruangan,
                Kapasitas = kapasitas,
                jReservasi = jadwalReservasiBaru,
                Status = StatusReservasiEnum.Aktif,
                AlasanPembatalan = ""
            };

            // Simpan data reservasi ke list dan file
            _reservasiList.Add(dataBaru);
            _statusReservasi.DaftarReservasi.Add(dataBaru);
            _statusReservasi.SimpanReservasiKeFile();

            return $"Sukses: Reservasi oleh {_user.Nama} untuk {tempat} {ruangan} pada {tanggal} {jamMulai}-{jamSelesai} berhasil.";
        }
        catch (Exception ex)
        {
            return $"Gagal: Terjadi kesalahan. ({ex.Message})";
        }
    }
}
