using System.Globalization;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

public class ReservasiRuangan<TUser, TJadwal, TReservasi>
    where TUser : User
    where TJadwal : Jadwal
    where TReservasi : DataReservasi, new()

{
    private TUser _user;
    private List<TJadwal> _jadwalList;
    private List<TReservasi> _reservasiList;
    private DaftarKelas _daftarKelas;
    private StatusReservasi _statusReservasi;

    public ReservasiRuangan(TUser user, List<TJadwal> jadwalList, List<TReservasi> reservasiList, DaftarKelas daftarKelas, StatusReservasi statusReservasi)
    {
        _user = user;
        _jadwalList = jadwalList;
        _reservasiList = reservasiList;
        _daftarKelas = daftarKelas;
        _statusReservasi = statusReservasi;
    }

    public string LakukanReservasi(string tempat, string ruangan, int kapasitas, string tanggal, string jamMulai, string jamSelesai)
    {
        try
        {
            DateTime tanggalReservasi = DateTime.Parse(tanggal);
            string hariDariTanggal = tanggalReservasi.ToString("dddd", new CultureInfo("id-ID"));

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

            JadwalReservasi jadwalReservasiBaru = new JadwalReservasi
            {
                NamaUser = _user.Nama,
                Tanggal = tanggal,
                Mulai = jamMulai,
                Selesai = jamSelesai
            };

            TReservasi dataBaru = new TReservasi
            {
                Tempat = tempat,
                Ruangan = ruangan,
                Kapasitas = kapasitas,
                jReservasi = jadwalReservasiBaru,
                Status = StatusReservasiEnum.Aktif,
                AlasanPembatalan = ""
            };

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
