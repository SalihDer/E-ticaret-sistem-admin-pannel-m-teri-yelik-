using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lsad.Models
{
    public class SepeteEkle
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public virtual  Products product { get; set; }
        public virtual ApplicationUser user { get; set; }



    }
}