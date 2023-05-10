using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revif
{
    public class BeliJasa
    {
        public BeliJasa() { }
        public Pesanan bikinPesanan(Akun akun, string nama_pesanan,
            string jenis_jasa, string deskripsi_pesanan)
        {
            Pesanan pesanan = new Pesanan();
            pesanan.akunPenyedia = akun;
            pesanan.nama_pesanan = nama_pesanan;
            pesanan.jenis_jasa = jenis_jasa;
            pesanan.deskripsi_pesanan = deskripsi_pesanan;
            pesanan.status_pesanan = "Belum terbayar";
            return pesanan;
        }
        public Pesanan tambahPesanan(List<Akun> lis)
        {
            Pesanan data;
            Akun akun = cariAkun(lis);
            Console.Write("Enter Order Name : ");
            string nama_pesanan = Console.ReadLine();
            Console.Write("Enter Jenis Order : ");
            string jenis_jasa = Console.ReadLine();
            Console.Write("Enter Order Description : ");
            string deskripsi_pesanan = Console.ReadLine();
            data = bikinPesanan(akun, nama_pesanan, jenis_jasa, deskripsi_pesanan);
            return data;
        }

        geser.geser gsr = new geser.geser();

        public Akun cariAkun(List<Akun> lis)
        {
            Console.Write("Enter Penyedia Jasa : ");
            string cariAkun = Console.ReadLine();
            Akun akun = new Akun("", ""); int i;
            while (akun.username != cariAkun)
            {
                i = 0;
                while (gsr.geserr<Akun>(lis, i))
                {
                    if (lis[i].username == cariAkun)
                    {
                        akun = lis[i];
                    }
                    i++;
                }
                if (akun.username == "")
                {
                    Console.WriteLine("Username not found.");
                    Console.Write("Enter Penyedia Jasa : ");
                    cariAkun = Console.ReadLine();
                }
            }
            return akun;
        }
        public void tambahDataPesanan(Akun akun, List<Akun> lis)
        {
            Pesanan pesanan = tambahPesanan(lis);
            akun.pembeli.pemesanan.Add(pesanan);
        }
    }
}
