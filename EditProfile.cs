using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revif
{
    public class EditProfile
    {
        public Akun akun;
        public enum dataan
        {
            email,
            username,
            password
        }

        public string[] infoAkun;
        public EditProfile(Akun akun)
        {
            this.akun = akun;
            infoAkun = new string[3];
            infoAkun[0] = akun.email;
            infoAkun[1] = akun.username;
            infoAkun[2] = akun.password;
        }

        public Akun EditUsername(Akun akunn)
        {
            LoginConvig loginConvig = new LoginConvig();
            loginConvig.ReadKonfigFile();
            int i;
            for (i = 0;i < loginConvig.ListAkun.akun.Count;i++)
            {
                if (loginConvig.ListAkun.akun[i].username == akunn.username && loginConvig.ListAkun.akun[i].password == akunn.password)
                {
                    Console.Write("Input new username: ");
                    string newUsername = Console.ReadLine();

                    Debug.Assert(newUsername != null && newUsername.Length <= 15, "Username tidak boleh melebihi 15 karakter atau kosong");

                    if (newUsername == loginConvig.ListAkun.akun[i].username)
                    {
                        Console.WriteLine("Username already registered");
                    }
                    else
                    {
                        Console.Write("Are you sure you want to change your username to " + newUsername + "? (y/n): ");
                        string confirm = Console.ReadLine();
                        if (confirm == "y")
                        {
                            loginConvig.ListAkun.akun[i].username = newUsername;
                        }
                        string confirmed = (confirm == "y") ? "Username has been changed" : "Username did not change";
                        Console.WriteLine(confirmed);
                    }
                    break;
                }

            }
            loginConvig.WriteKonfigFile();
            return loginConvig.ListAkun.akun[i];
        }

        public Akun EditPassword(Akun akunn)
        {
            LoginConvig loginConvig = new LoginConvig();
            loginConvig.ReadKonfigFile();
            int i;

            for (i = 0; i < loginConvig.ListAkun.akun.Count; i++)
            {
                if (loginConvig.ListAkun.akun[i].username == akunn.username && loginConvig.ListAkun.akun[i].password == akunn.password)
                {
                    Console.Write("Input new password: ");
                    string newPassword = Console.ReadLine();

                    Debug.Assert(newPassword != null && newPassword.Length <= 15, "Username tidak boleh melebihi 15 karakter atau kosong");

                    if (newPassword == loginConvig.ListAkun.akun[i].password)
                    {
                        Console.WriteLine("password already registered");
                    }
                    else
                    {
                        Console.Write("Please rewrite your password: ");
                        string confirm = Console.ReadLine();
                        if (confirm == newPassword)
                        {
                            loginConvig.ListAkun.akun[i].password = newPassword;
                        }
                        string confirmed = (confirm == newPassword) ? "Password has been changed" : "Password did not change";
                        Console.WriteLine(confirmed);
                    }
                    break;
                }

            }
            loginConvig.WriteKonfigFile();
            return loginConvig.ListAkun.akun[i];
        }

        public bool cekPassword(Akun akun, string password)
        {
            if (akun.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cekUsername(Akun akun, string uname)
        {
            if (akun.username == uname)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Akun gantiPassword(Akun akun,string newPassword)
        {
            akun.password = newPassword;
            return akun;
        }

        public Akun gantiUname(Akun akun, string newUname)
        {
            akun.username = newUname;
            return akun;
        }

    }
}