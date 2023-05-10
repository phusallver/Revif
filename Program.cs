using PesananLibrary;
public class Program
{
    public static void Main()
    {
        Pesanan pesanan = new Pesanan("Jasa Penulisan Artikel", "Penulisan artikel 500 kata", 2, 100000);

        // Tampilkan detail pesanan
        pesanan.ShowDetail();
        Console.WriteLine("");

        // Bayar pesanan dengan metode pembayaran "Transfer"
        pesanan.Bayar("Transfer");
        Console.WriteLine("");
        pesanan.ShowDetail();
        Console.WriteLine("");

        // Konfirmasi pesanan selesai
        pesanan.KonfirmasiSelesai();
        Console.WriteLine("");

        // Tampilkan detail pesanan setelah selesai
        pesanan.ShowDetail();
    }
}