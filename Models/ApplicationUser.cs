using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }



        public string Sehir { get; set; }
        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }
    }
}
