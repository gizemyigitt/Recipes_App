using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Tatli> Tatli { get; set; }
        public IEnumerable<Kategori> Kategori { get; set; }
        public IEnumerable<Malzeme> Malzeme { get; set; }
        public IEnumerable<TatliMalzeme> TatliMalzeme { get; set; }
        public IEnumerable<DunyaMutfak> DunyaMutfak { get; set; }
        public IEnumerable<Tarifler> Tarifler { get; set; }
    }
}
