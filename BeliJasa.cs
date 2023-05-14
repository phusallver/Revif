using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Revif
{
    public class BeliJasa
    {
        public BeliJasa() { }
        public Pesanan bikinPesanan(Akun akun, string nama_pesanan,
            string jenis_jasa, string deskripsi_pesanan)
        {
            Pesanan pesanan = new Pesanan();
            pesanan.akun_penyedia = akun.username;
            pesanan.nama_pesanan = nama_pesanan;
            pesanan.jenis_jasa = jenis_jasa;
            pesanan.deskripsi_pesanan = deskripsi_pesanan;
            pesanan.status_pesanan = "Belum terbayar";
            return pesanan;
        }
        public Pesanan tambahPesanan(List<Akun> lis, Akun akun_penjual)
        {
            Pesanan data;
            Console.Write("Enter Order Name : ");
            string nama_pesanan = Console.ReadLine();
            Console.Write("Enter Jenis Order : ");
            string jenis_jasa = Console.ReadLine();
            Console.Write("Enter Order Description : ");
            string deskripsi_pesanan = Console.ReadLine();
            data = bikinPesanan(akun_penjual, nama_pesanan, jenis_jasa, deskripsi_pesanan);
            return data;
        }
        geser.geser gsr = new geser.geser();

        public Akun cariAkun(List<Akun> lis, string cari_uname)
        {
            Debug.Assert(cari_uname != null);
            Akun akun = new Akun("", ""); int i;
            while (akun.username != cari_uname)
            {
                i = 0;
                while (gsr.geserr<Akun>(lis, i))
                {
                    if (lis[i].username == cari_uname)
                    {
                        akun = lis[i];
                    }
                    i++;
                }
                if (akun.username == "")
                {
                    Console.WriteLine("Username not found.");
                    Console.Write("Enter Penyedia Jasa : ");
                    cari_uname = Console.ReadLine();
                }
            }
            return akun;
        }
        public void cekPemesanan(Akun akun)
        {
            int i = 1;
            foreach (Pesanan pesanan in akun.pembeli.pemesanan)
            {
                Console.WriteLine(i + ". ");
                Console.WriteLine("Order    : " + pesanan.nama_pesanan);
                Console.WriteLine("Artist   : " + pesanan.akun_penyedia);
                Console.WriteLine("Status   : " + pesanan.status_pesanan);
                i++;
            }
        }
        public void tambahDataPesanan(Akun akun, List<Akun> lis)
        {
            Console.Write("Enter Penyedia Jasa : ");
            string cari_uname = Console.ReadLine();
            Akun akun_penjual = cariAkun(lis, cari_uname);
            Pesanan pesanan = tambahPesanan(lis, akun_penjual);
            akun.pembeli.pemesanan.Add(pesanan);
            akun_penjual.penjual.pesanan.Add(pesanan);
        }
    }
}
