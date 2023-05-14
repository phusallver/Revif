using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//state-based states and triggers
public enum AkunState { Penjual, Pembeli, Logout}
public enum Trigger { switchMode, keluar }

namespace Revif
{
    public class Menu
    {
        AkunState currentState;
        PosisiMenu sekarang;
        //state-based
        class Transition
        {
            public AkunState stateAwal;
            public AkunState stateAkhir;
            public Trigger trigger;
            public Transition(AkunState stateAwal, AkunState stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }
        Transition[] transitions =
        {
            new Transition(AkunState.Pembeli, AkunState.Penjual, Trigger.switchMode),
            new Transition(AkunState.Penjual, AkunState.Pembeli, Trigger.switchMode),
            new Transition(AkunState.Penjual, AkunState.Logout, Trigger.keluar),
            new Transition(AkunState.Pembeli, AkunState.Logout, Trigger.keluar)
        };
        //--
        public Menu() 
        {
            currentState = AkunState.Logout;
            sekarang = PosisiMenu.MainPenyedia;
        }
        public AkunState getNextState(AkunState prevState, Trigger trigger)
        {
            AkunState nextState = prevState;
            foreach (var transition in transitions)
            {
                if (transition.stateAwal == prevState && transition.trigger == trigger)
                {
                    nextState = transition.stateAkhir;
                }
            }
            return nextState;
        }
        //table-driven
        public enum PosisiMenu
        {
            MainPembeli, MainPenyedia,
            PilihJasa, CekPesanan,
            CekPermintaan, TampilkanJasa,
            EditProfile
        }
        public string[] getMenus(PosisiMenu posisi)
        {
            string[][] value =
                {
                    new string[] { "1. Edit Profile", "2. Buat Pemesanan", "3. Cek Pemesanan", "4. Switch role", "0. Log out" },
                    new string[] { "1. Unggah Portofolio", "2. Pesanan", "3. Tampilkan Jasa", "4. Switch role", "0. Log out" },
                    new string[] { "1. Buat Gambar", "2. Edit Video", "3. Voice Acting" },
                    new string[] { "1. Pesanan 1", "2. Pesanan 2" },
                    new string[] { "1. Permintaan 1", "2. Permintaan 2" },
                    new string[] { "1. Jasa 1", "2. Jasa 2" },
                    new string[] { "1. Edit email", "2. Edit username", "3. Change password" }
                };
            string[][] pilihanMenu = value;
            return pilihanMenu[(int)posisi];
        }
        //--
        private void printSekarang(PosisiMenu posisi)
        {
            foreach (string menu in getMenus(posisi))
            {
                Console.WriteLine(menu);
            }
        }

        public void masuk()
        {
            Console.Write("Login sebagai :\n" +
                "1. Pembeli Jasa\n" +
                "2. Penjual Jasa\n" +
                "Pilihan (1/2): ");
            string pilihan = Console.ReadLine();
            while(pilihan !="1" &&  pilihan !="2")
            {
                Console.WriteLine("\nInputan tidak valid, silahkan input ulang.\n");
                Console.Write("Login sebagai :\n" +
                "1. Pembeli Jasa\n" +
                "2. Penjual Jasa\n" +
                "Pilihan : ");
                pilihan = Console.ReadLine();
            }
            if ( pilihan == "1")
            {
                currentState = AkunState.Pembeli;
                sekarang = PosisiMenu.MainPembeli;
            }
            else
            {
                currentState = AkunState.Penjual;
                sekarang = PosisiMenu.MainPenyedia;
            }

            while (currentState != AkunState.Logout)
            {
                if (currentState == AkunState.Penjual)
                {
                    penjual();
                }
                if (currentState == AkunState.Pembeli)
                {
                    pembeli();
                }
            }
        }
        public void penjual()
        {
            while (currentState == AkunState.Penjual)
            {
                Console.WriteLine("-=============: MENU :=============-");
                Console.WriteLine("\nSilahkan pilih salah satu (angka): ");
                printSekarang(sekarang);
                Console.Write("Pilihan : ");
                string pilihan = Console.ReadLine();
                if (pilihan == "1")
                {
                    //unggah porto/jasa
                    Console.WriteLine("Masukkan info jasa...");
                    string infoJasa = Console.ReadLine();
                    Console.WriteLine("(memanggil kelas lain)\nJasa telah ditambahkan");
                    Console.WriteLine("\nKembali ke menu utama...\n");
                }
                else if (pilihan == "2")
                {
                    //menampilkan list permintaan/pesanan
                    Console.WriteLine("Berikut daftar pesanan : ");
                    sekarang = PosisiMenu.CekPermintaan;
                    printSekarang(sekarang);
                    Console.WriteLine("\nKembali ke menu utama...\n");
                    sekarang = PosisiMenu.MainPenyedia;
                }
                else if (pilihan == "3")
                {
                    //menampilkan jasa yang ditawarkan
                    Console.WriteLine("Berikut daftar jasa yang anda tawarkan : ");
                    sekarang = PosisiMenu.TampilkanJasa;
                    printSekarang(sekarang);
                    Console.WriteLine("\nKembali ke menu utama...\n");
                    sekarang = PosisiMenu.MainPenyedia;
                }
                else if (pilihan == "4")
                {
                    //switch
                    Console.WriteLine("\nBeralih mode akun...\n");
                    currentState = getNextState(currentState, Trigger.switchMode);
                    sekarang = PosisiMenu.MainPembeli;
                }
                else if (pilihan == "0")
                {
                    Console.WriteLine("\nKeluar dari program\n");
                    currentState = getNextState(currentState, Trigger.keluar);
                }
                else
                {
                    Console.WriteLine("\nInputan tidak valid, silahkan melakukan input ulang.\n");
                }
                Console.WriteLine("-===================================-\n\n");
            }
        }
        public void pembeli()
        {
            while (currentState == AkunState.Pembeli)
            {
                Console.WriteLine("-=============: MENU :=============-");
                Console.WriteLine("\nSilahkan pilih salah satu (angka): ");
                printSekarang(sekarang);
                Console.Write("Pilihan : ");
                string pilihan = Console.ReadLine();
                if (pilihan == "1")
                {
                    //edit profile
                    Console.WriteLine("\nSilahkan pilih info yang akan di edit :\n");
                    sekarang = PosisiMenu.EditProfile;
                    printSekarang(sekarang);
                    Console.Write("Pilihan : ");
                    int pilihinfobaru = Convert.ToInt32(Console.ReadLine());
                    Debug.Assert(pilihinfobaru > 0 && pilihinfobaru <= 3, "Input tidak valid!");
                    Console.Write("Masukkan yang baru : ");
                    string infobaru = Console.ReadLine();
                    Console.WriteLine("\nKembali ke menu utama...\n");
                    sekarang = PosisiMenu.MainPembeli;
                }
                else if (pilihan == "2")
                {
                    //buat pemesanan
                    Console.WriteLine("Masukkan info pesanan...");
                    string infoJasa = Console.ReadLine();
                    Console.WriteLine("(memanggil kelas lain)\nPesanan telah dibuat");
                    Console.WriteLine("\nKembali ke menu utama...\n");
                }
                else if (pilihan == "3")
                {
                    //cek pemesanan
                    Console.WriteLine("Berikut daftar pesanan : ");
                    sekarang = PosisiMenu.CekPesanan;
                    printSekarang(sekarang);
                    Console.WriteLine("\nKembali ke menu utama...\n");
                    sekarang = PosisiMenu.MainPembeli;
                }
                else if (pilihan == "4")
                {
                    //switch
                    Console.WriteLine("\nBeralih mode akun...\n");
                    currentState = getNextState(currentState, Trigger.switchMode);
                    sekarang = PosisiMenu.MainPenyedia;
                }
                else if (pilihan == "0")
                {
                    Console.WriteLine("\nKeluar dari program\n");
                    currentState = getNextState(currentState, Trigger.keluar);
                }
                else
                {
                    Console.WriteLine("\nInputan tidak valid, silahkan melakukan input ulang.\n");
                }
                Console.WriteLine("-===================================-\n\n");
            }
        }
    }
}

