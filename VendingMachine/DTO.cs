using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class DTO
    {
        public class barang
        {
            public string kode_barang { get; set; }
            public string nama_barang { get; set; }
            public decimal harga { get; set; }
            public int stock { get; set; }
            public string image { get; set; }
        }
    }
}
