using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace deneme.Entity
{
    public class VeriBaglam:DbContext
    {

        public VeriBaglam():base("dataConnection") 
        {
           

        }

        public DbSet<urun> uruns { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }

    }
}