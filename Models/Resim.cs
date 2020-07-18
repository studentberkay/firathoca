using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FiratHoca.Models
{
    public class Resim
    {
        public int Id { get; set; }
        public string DosyaAdi { get; set; }

        //------ilişkileri-----
        public int BebekuId { get; set; } //scaler
        [Required]
        public Bebek Bebeku { get; set; }  //FK BebekuId
    }
}
