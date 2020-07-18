using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FiratHoca.Models
{
    public class Bebek //tekil
    {
        public Bebek()
        {
            Resimler = new List<Resim>();
        }
        [Key]
        //TCKimlikNumarasi
        //BebekId
        public int Id { get; set; }

        [Display(Name="Adı")]
        [Required(ErrorMessage="{0} alanı boş geçilmemelidir")]
        public string Ad { get; set; }

        [Display(Name="Açıklama")]
        [Required(ErrorMessage="{0} alanı boş geçilmemelidir")]
        public string Aciklama { get; set; }

        [Display(Name="Kiloı")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")]
        [Required(ErrorMessage="{0} alanı boş geçilmemelidir")]
        public decimal Kilo { get; set; }

        [NotMapped]  //Veritabanına yansımamasını sağlar
        public IFormFile[] Dosyalar { get; set; }

        // -----ilişkiler---
        public List<Resim> Resimler { get; set; }
    }
}
