using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class Malzeme
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public double Miktar { get; set; }

        public Birim Birim { get; set; }

        public string MiktarBirimAd
        {
            get { return Miktar + " " + Birim + " " + Ad; }
        }


    }
    public enum Birim
    {
        Adet,
        Gram,
        Mililitre,

    }
}

