using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaMVC.Models
{
    public class ShippingDetails
    {
        
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen Gerekli alanı doldurunuz.")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen Gerekli alanı doldurunuz.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen Gerekli alanı doldurunuz.")]
        public string Sehir { get; set; }


    }
}