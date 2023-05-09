using PesananLibrary;
public class Program
{
    public static void Main()
    {
        Pesanan pesanan = new Pesanan("Penerjemahan Bahasa Inggris-Indonesia", "Terjemahkan dokumen bisnis", 3, 500000);


        pesanan.ShowDetail();
        Console.WriteLine("");

        // Lakukan pembayaran
        pesanan.Bayar("Dana");
        pesanan.ShowDetail();
        Console.WriteLine("");


        // Lakukan konfirmasi selesai
        pesanan.KonfirmasiSelesai();
        pesanan.ShowDetail();
        Console.WriteLine("");
    }
}