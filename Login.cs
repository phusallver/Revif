using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Revif
{
    internal class Login
    {
        
        public void ReadJSON()
        {
            string jsonString = File.ReadAllText("C:\\Telkom\\Semester 4\\KPL\\tubes\\Revif\\contohLogin.json");
            LoginData user1 = JsonSerializer.Deserialize<LoginData>(jsonString);

            Console.WriteLine(user1.username);
        }

        enum Role
        {
            pembeli_jasa,
            penjual_jasa
        }

        /*public void inputData()
        {
            Console.Write("Tuliskan email: ");
            this.email = Console.ReadLine();

            Console.Write("Tuliskan username: ");
            this.username = Console.ReadLine();

            Console.Write("Tuliskan password: ");
            this.password = Console.ReadLine();

            Console.WriteLine("pembeli jasa : 0, penjual jasa : 1");
            string role = Console.ReadLine();
            int intRole =   Convert.ToInt32(role);

            Role jenisRole = (Role)intRole;
        }
        */
    }

    internal class LoginData
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }

    }
}
