using Revif;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        LoginConvig loginConvig = new LoginConvig();
        bool login = false;
        Akun akunMasuk;
        Console.WriteLine("Silahkan log in...");
        while (!login)
        {
            Console.Write("Username : ");
            string username = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            foreach (Akun akun in loginConvig.ListAkun.akun)
            {
                if (akun.username == username && akun.password == password)
                {
                    akunMasuk = akun;
                    login = true;
                }

            }
            if (!login)
            {
                Console.WriteLine("Username atau password salah, silahkan masukkan kembali...");
            }
        }
        EditProfile edit = new EditProfile(loginConvig.ListAkun.akun[1]);
        Console.WriteLine("Username sebelum : " + loginConvig.ListAkun.akun[1].username);
        edit.username();
        Console.WriteLine("Username sesudah : " + loginConvig.ListAkun.akun[1].username);
        /*
        BeliJasa beliJasa = new BeliJasa();
        beliJasa.tambahDataPesanan(loginConvig.ListAkun.akun[1], loginConvig.ListAkun.akun);
        Console.WriteLine(loginConvig.ListAkun.akun[1].pembeli.pemesanan[0].deskripsi_pesanan);

        Menu menu = new Menu();
        menu.masuk();*/
    }
}