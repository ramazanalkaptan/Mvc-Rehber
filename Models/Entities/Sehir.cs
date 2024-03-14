using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcRehber.Models.Entities
{
    [Table("Sehirler")]
    public class Sehir
    {
        public int Id { get; set; }
        public string SehirAdi { get; set; }
        public int PlakaKodu { get; set; }
    }
}