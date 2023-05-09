using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revif
{
    internal class DataPenggunaJasa
    {
        public string Fullname { get; set; }

        public string Username { get; set; }
        public string AccountDescription { get; set; }
        public List<string> Languages { get; set; }
        public List<jasa> listJasa { get; set; }
        public DataPenggunaJasa() { }
    }
}
