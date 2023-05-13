using PesananLibrary;
public class Program
{
    public static void Main()
    {
        Pesanan pesanan1 = new Pesanan("Jasa Penulisan Artikel", "Penulisan artikel mendukung banteng merah", 2, 100000);

        // Tampilkan detail pesanan
        pesanan1.ShowDetail();
        Console.WriteLine("");

        // Bayar pesanan dengan metode pembayaran "Transfer"
        pesanan1.Bayar("Transfer Bank");
        Console.WriteLine("");
        pesanan1.ShowDetail();
        Console.WriteLine("");

        // Konfirmasi pesanan selesai
        pesanan1.KonfirmasiSelesai();
        Console.WriteLine("");

        // Tampilkan detail pesanan setelah selesai
        pesanan1.ShowDetail();


        Console.WriteLine("================================================================\n");
        Pesanan pesanan2 = new Pesanan("Jasa Design Poster", "Membuat design poster untuk kampanye megachan", 3, 1500000);

        // Tampilkan detail pesanan
        pesanan2.ShowDetail();
        Console.WriteLine("");

        // Melakukan pembatalan
        pesanan2.BatalPesanan();
        Console.WriteLine("");
        pesanan2.ShowDetail();
    }
}