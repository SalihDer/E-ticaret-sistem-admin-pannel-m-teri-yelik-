using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace lsad.Models
{
    public class Products

    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public String ProductTitle { get; set; }
        [DisplayName("Product Content")]

        public String ProductContent { get; set; }
        [DisplayName("Product Image")]

        public String ProductImage { get; set; }
        [DisplayName("Product Price")]

        public String ProductPrice { get; set; }
        [DisplayName("Product Color")]
        public String ProductColor { get; set; }
        [DisplayName("Product Weight")]
        public String ProductWeight { get; set; }
        [DisplayName("Product Type")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}