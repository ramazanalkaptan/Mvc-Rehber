using MvcRehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcRehber.Models.Context
{
    public class MvcRehberContext : DbContext
    {
        public MvcRehberContext() : base("Server=DESKTOP-T8E3K8K;Database=MvcRehberDB1;Trusted_Connection=true")
        {
            
        }



        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
    }
}