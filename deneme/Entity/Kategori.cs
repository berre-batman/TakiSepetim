using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace deneme.Entity
{
    public class Kategori
    {
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public List<urun> uruns { get; set; }
        
    }
}