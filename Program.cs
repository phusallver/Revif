using Revif;

internal class Program
{
    private static void Main(string[] args)
    {
        UnggahJasaConfig config = new UnggahJasaConfig();
        //config.tambahData();
        Console.WriteLine("-------------MENU-------------");
        Console.WriteLine("1. Tambah data jasa");
        Console.WriteLine("2. Show data pengguna beserta jasa");
        Console.WriteLine("3. EXIT");
        config.menu();  
    }
}