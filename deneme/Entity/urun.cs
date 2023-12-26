using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace deneme.Entity
{
    public class urun
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        public double Fiyat { get; set; }

        public int Stok { get; set; }
        public string Image {  get; set; }

        public bool ishome { get; set; }
        public bool Onay { get; set; }


        public int KategoriId { get; set; }
        public Kategori Kategoris { get; set;}

    }
}