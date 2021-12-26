using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class Tarifler
    {
        public int Id { get; set; }

        public int KategoriId { get; set; }

        public int TatliId { get; set; }

        public Tatli Tatli { get; set; }

        public Kategori Kategori { get; set; }
    }
}
