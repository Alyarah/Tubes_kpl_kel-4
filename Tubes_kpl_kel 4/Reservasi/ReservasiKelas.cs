using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

public class ReservasiRuangan
{
    private User _user;
    private List<Jadwal> _jadwalList;
    private List<DataReservasi> _reservasiList;
    private DaftarKelas _daftarKelas;

    public ReservasiRuangan(User user, List<Jadwal> jadwalList, List<DataReservasi> reservasiList, DaftarKelas daftarKelas)
    {
        _user = user;
        _jadwalList = jadwalList;
        _reservasiList = reservasiList;
        _daftarKelas = daftarKelas;
    }

    public string LakukanReservasi(string tempat, string ruangan, int kapasitas, string tanggal, string jamMulai, string jamSelesai)
    {
        DateTime tanggalReservasi = DateTime.Parse(tanggal);
        string hariDariTanggal = tanggalReservasi.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

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

        return $"Sukses: Reservasi oleh {_user.Nama} untuk {tempat} {ruangan} pada {tanggal} {jamMulai}-{jamSelesai} berhasil.";
    }

    public void CariKelasBerdasarkanTanggal(string tanggal)
    {
        var kelasTersedia = _daftarKelas.ListKelas.Where(jadwal => jadwal.Hari.Equals(tanggal)).ToList();

        if (kelasTersedia.Any())
        {
            Console.WriteLine("=== Kelas yang Tersedia pada Tanggal " + tanggal + " ===");
            foreach (var jadwal in kelasTersedia)
            {
                Console.WriteLine($"{jadwal.Hari} | {jadwal.Tempat} - {jadwal.Ruangan} | Kapasitas: {jadwal.Kapasitas} orang | {jadwal.Mulai} - {jadwal.Selesai}");
            }
        }
        else
        {
            Console.WriteLine($"Tidak ada kelas yang tersedia pada tanggal {tanggal}.");
        }
    }
}