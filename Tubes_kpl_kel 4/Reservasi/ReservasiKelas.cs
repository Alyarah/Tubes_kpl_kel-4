using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

public class ReservasiRuangan
{
    private readonly User _user;
    private readonly List<Jadwal> _jadwalList;
    private readonly List<DataReservasi> _reservasiList;

    public ReservasiRuangan(User user, List<Jadwal> jadwalList, List<DataReservasi> reservasiList)
    {
        _user = user;
        _jadwalList = jadwalList;
        _reservasiList = reservasiList;
    }

    public string LakukanReservasi(string tempat, string ruangan, int kapasitas, string tanggal, string jamMulai, string jamSelesai, string hari)
    {
        foreach (var jadwal in _jadwalList)
        {
            if (jadwal.Tempat == tempat && jadwal.Ruangan == ruangan && jadwal.Hari.Equals(hari, StringComparison.OrdinalIgnoreCase))
            {
                if (jamMulai.CompareTo(jadwal.Selesai) < 0 && jamSelesai.CompareTo(jadwal.Mulai) > 0)
                {
                    return $"Gagal: Jadwal tetap di {tempat} {ruangan} bentrok dengan waktu {jadwal.Mulai}-{jadwal.Selesai}.";
                }
            }
        }

        foreach (var reservasi in _reservasiList)
        {
            if (reservasi.Tempat == tempat && reservasi.Ruangan == ruangan && reservasi.Tanggal == tanggal)
            {
                if (jamMulai.CompareTo(reservasi.Selesai) < 0 && jamSelesai.CompareTo(reservasi.Mulai) > 0)
                {
                    return $"Gagal: Sudah dipesan oleh {reservasi.NamaPemesan} dari {reservasi.Mulai} sampai {reservasi.Selesai}.";
                }
            }
        }

        return $"Sukses: Reservasi oleh {_user.Nama} untuk {tempat} {ruangan} pada {tanggal} {jamMulai}-{jamSelesai} berhasil.";
    }
}