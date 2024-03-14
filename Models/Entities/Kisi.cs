using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcRehber.Models.Entities
{
    [Table("Kisiler")] // Veri tabanı adını Kisiler yapar.
    public class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [DisplayName("Ev Telefonu")] // Modelden aldıgımız isimleri bu şekilde göstericektir.
        public string EvTelefon { get; set; }
        [DisplayName("Cep Telefonu")]
        public string CepTelefon { get; set; }
        [DisplayName("İş Telefonu")]
        public string IsTelefon { get; set; }
        [DisplayName("E-mail Adresi")]
        public string EmailAdres { get; set; }
        public string Adres { get; set; }
        [DisplayName("Şehir")]
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }


    }
}