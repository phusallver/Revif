using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Revif
{
    public class UnggahJasaConfig
    {
        private const string filepath = @"login_convig.json";
        public Konfig listAkun;
        public UnggahJasaConfig() //rewrite
        {
            listAkun = ReadKonfigFile<Konfig>();
        }
        public Tipe ReadKonfigFile<Tipe>()
        {
            string hasilBaca = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<Tipe>(hasilBaca);
        }
        public void WriteKonfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string tulisan = JsonSerializer.Serialize(listAkun, options);
            File.WriteAllText(filepath, tulisan);
        }

        public Jasa bikinDataJasa(string jenis, int harga, string deskripsi)
        {
            Jasa data = new Jasa();
            data.jenis_jasa = jenis;
            data.harga = harga;
            data.deskripsi = deskripsi;
            return data;
        }
        public Jasa tambahJasa()
        {
            Jasa data = new Jasa();
            Console.Write("Enter Service Name : ");
            string service = Console.ReadLine();
            Debug.Assert(service != null && service.Length <= 20, "Service name can't be empty or letters cannot be more than 20 letters ");
            
            int harga = 0;
            try
            {
                Console.Write("Enter Price : ");
                harga = Convert.ToInt32(Console.ReadLine());
                Debug.Assert(harga != null && harga >= 0 && harga >= 10000, "Price can't be empty, minus, or below 10k");
            }
            catch
            {
                bool status = false;
                while (status != true)
                {
                    Console.Write("Input is wrong. Re Enter Price : ");
                    try
                    {
                        harga = Convert.ToInt32(Console.ReadLine());
                        Debug.Assert(harga != null && harga >= 0 && harga >= 10000, "Price can't be empty, minus, or below 10k");
                        status = true;
                    }
                    catch
                    {
                        status = false;
                    }
                }
            }

            Console.Write("Enter Description : ");
            string desc = Console.ReadLine();
            Debug.Assert(desc != null && desc.Length <= 100, "Description can't be empty or description length cannot be more than 100 letters");

            data = bikinDataJasa(service, harga, desc);
            return data;
        }
        public void tambahData(string username) //rewrite 
        {
            Konfig obj = ReadKonfigFile<Konfig>();
            for (int i = 0; i < obj.akun.Count; i++)
            {
                if (obj.akun[i].username == username)
                {
                    Jasa dataJasa = new Jasa();
                    dataJasa = tambahJasa();
                    obj.akun[i].penjual.jasa.Add(dataJasa);
                }
            }
            listAkun = obj;
            WriteKonfigFile();
        }
        public void showData(Akun akun)
        {
            int i = 1;
            foreach (Jasa jasa in akun.penjual.jasa)
            {
                Console.WriteLine(i + ". ");
                Console.WriteLine("GAMBAR PROMOSI");
                Console.WriteLine("Title : " + jasa.jenis_jasa);
                Console.WriteLine("Price : " + jasa.harga);
                Console.WriteLine("Service Description : " + jasa.deskripsi);
                i++;
            }
        }
    }
}

