using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lsad.Models
{
    public class Category

    {
        public int Id { get; set; }
        [Required]
        [Display(Name =" Product Type")]
        public string CategoryName { get; set; }
        public virtual ICollection<Products> Product { get; set; }



    }
}