using Revif;

internal class Program
{
    private static void Main(string[] args)
    {
        LoginConvig loginConvig = new LoginConvig();
        bool login = false;
        Akun akunMasuk = new Akun();
        EditProfile editprof = new EditProfile(akunMasuk);

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

        akunMasuk = editprof.EditUsername(akunMasuk);
        akunMasuk = editprof.EditPassword(akunMasuk);
        
    }
}   