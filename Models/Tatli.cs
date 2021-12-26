using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class Tatli
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Tarif { get; set; }


        public int? DunyaMutfakId { get; set; }
        public DunyaMutfak DunyaMutfak { get; set; }
        public string TatlıFoto { get; set; }
        public int? KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public int KisiSayisi { get; set; }
      
    }
}
