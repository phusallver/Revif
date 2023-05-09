using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Revif
{
    internal class UnggahJasaConfig
    {
        private const string filepath = @"jasa_config.json";
        public List<DataPenggunaJasa> user = new List<DataPenggunaJasa>();
        public UnggahJasaConfig()
        {
            try
            {
                List<DataPenggunaJasa> obj = ReadKonfigFile<List<DataPenggunaJasa>>(filepath);
            }
            catch
            {
                setDefault();
                WriteKonfigFile(filepath);
            }
        }
        public Tipe ReadKonfigFile<Tipe>(string filepath)
        {
            string hasilBaca = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<Tipe>(hasilBaca);
        }
        public void WriteKonfigFile(string filepath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string tulisan = JsonSerializer.Serialize(user, options);
            File.WriteAllText(filepath, tulisan);
        }

        public jasa bikinDataJasa(string judul, int harga, string deskripsi)
        {
            jasa data = new jasa();
            data.judul_jasa = judul;
            data.harga = harga;
            data.deskripsi = deskripsi;
            return data;
        }
        public jasa tambahJasa()
        {
            jasa data = new jasa();
            Console.WriteLine("Enter Title:");
            string judul = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            int harga = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Description:");
            string desc = Console.ReadLine();

            data = bikinDataJasa(judul, harga, desc);
            return data;
        }
        public void setDefault()
        {
            DataPenggunaJasa dataPengguna = new DataPenggunaJasa();
            dataPengguna.Fullname = "Default";
            dataPengguna.Username = "Default";
            dataPengguna.AccountDescription = "Default";
            List<string> bahasa = new List<string>();
            bahasa.Add("English");
            dataPengguna.Languages = bahasa;

            dataPengguna.listJasa = new List<jasa>();
            jasa dataJasa = new jasa();
            dataJasa.harga = 0;
            dataJasa.judul_jasa = "default";
            dataJasa.deskripsi = "default";
            dataPengguna.listJasa.Add(dataJasa);

            user.Add(dataPengguna);
            WriteKonfigFile(filepath);
        }
        public void tambahData(string username)
        {
            List<DataPenggunaJasa> obj = ReadKonfigFile<List<DataPenggunaJasa>>(filepath);
            for (int i = 0; i < obj.Count; i++)
            {
                if (obj[i].Username == username)
                {
                    bool status = false;
                    for (int j = 0; j < obj[i].listJasa.Count; j++)
                    {
                        if (obj[i].listJasa[j].judul_jasa == "default")
                        {
                            obj[i].listJasa.Clear();
                            jasa dataJasa2 = new jasa();
                            dataJasa2 = tambahJasa();
                            obj[i].listJasa.Add(dataJasa2);
                            status = true;
                            break;
                        }
                    }
                    if (status != true)
                    {
                        jasa dataJasa = new jasa();
                        dataJasa = tambahJasa();
                        obj[i].listJasa.Add(dataJasa);
                    }
                }
            }
            user = obj;
            WriteKonfigFile(filepath);
        }
        public void showData()
        {
            List<DataPenggunaJasa> obj = ReadKonfigFile<List<DataPenggunaJasa>>(filepath);
            for (int i = 0; i < obj.Count; i++)
            {
                Console.WriteLine("DATA PENGGUNA " + (i + 1) + ": ");
                Console.WriteLine("Username : " + obj[i].Username);
                Console.WriteLine("Fullname : " + obj[i].Fullname);
                Console.WriteLine("Account Description : " + obj[i].AccountDescription);
                Console.WriteLine("Username : " + obj[i].Languages[0]);
                Console.WriteLine(" -- Service -- ");
                for (int j = 0; j < obj[i].listJasa.Count; j++)
                {
                    Console.WriteLine("GAMBAR PROMOSI");
                    Console.WriteLine("Title : " + obj[i].listJasa[j].judul_jasa);
                    Console.WriteLine("Price : " + obj[i].listJasa[j].harga);
                    Console.WriteLine("Service Description : " + obj[i].listJasa[j].deskripsi);
                }
                Console.WriteLine();
            }
        }
        public void menu()
        {
            bool lanjut = true;

            while (lanjut)
            {
                Console.WriteLine("Masukkan menu yang diinginkan: ");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Masukkan username pengguna yang ingin ditambah data jasanya.");
                        string masuk = Console.ReadLine();
                        tambahData(masuk);
                        break;

                    case 2:
                        showData();
                        break;

                    case 3:
                        lanjut = false;
                        break;
                }
            }
        }
    }
}

