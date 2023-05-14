using Revif;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        BeliJasa bj = new BeliJasa();
        List<Akun> kn = new List<Akun>();

        kn.Add(new Akun("A", "adadsa"));
        kn.Add(new Akun("rasyid", "depok"));
        kn.Add(new Akun("bismillah", "sad"));

        Akun akun = new Akun("dd", "wili");
        kn.Add(akun);
        bj.tambahDataPesanan(akun, kn);

        bj.cekPemesanan(akun);

    }
}