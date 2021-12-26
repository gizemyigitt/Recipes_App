using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class TatliMalzeme
    {
        public int Id { get; set; }
        public int TatliId { get; set; }
        public int MalzemeId { get; set; }

        
       

        public Tatli Tatli { get; set; }
        public Malzeme Malzeme { get; set; }

    }
}
