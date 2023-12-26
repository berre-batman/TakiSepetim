using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace deneme.Entity
{
    public class VeriBaslat:DropCreateDatabaseIfModelChanges<VeriBaglam>
    {
        protected override void Seed(VeriBaglam context)
        {
            List<Kategori> kategoris = new List<Kategori>()
            {
                new Kategori(){Name="Yüzük",Description="Yüzük Açıklaması"},
                new Kategori(){Name="Bileklik",Description="Bileklik Açıklaması"},
                new Kategori(){Name="Kolye",Description="Kolye Açıklaması"},
                new Kategori(){Name="Küpe",Description="Küpe Açıklaması"},
                new Kategori(){Name="Halhal",Description="Halhal Açıklaması"},
                new Kategori(){Name="Şahmeran",Description="Şahmeran Açıklaması"}
            };

            foreach (var kategori in kategoris)
            {
                context.Kategoris.Add(kategori);
            }

            context.SaveChanges();

            var urunler = new List<urun>()
            {
            new urun() {Id=1, Name = "Gold Yüzük", Description = "Gold Detaylı Kadın Yüzük", Fiyat = 125, Stok = 25, Onay = true, KategoriId = 1 ,ishome=true,Image="1.jpg"},
            new urun() { Id=2,Name = "Gümüş Yüzük", Description = "Gümüş Detaylı Kadın Yüzük", Fiyat = 125, Stok = 25, Onay = true, KategoriId = 1 ,ishome=true,Image="2.jpg"},
            new urun() { Id=3,Name = "Gold Bileklik", Description = "Gold Detaylı Kadın Bileklik", Fiyat = 75, Stok = 52, Onay = true, KategoriId = 2 ,ishome=true,Image="3.jpeg"},
            new urun() { Id=4,Name = "Gümüş Bileklik", Description = "Gümüş Detaylı Kadın Bileklik", Fiyat = 75, Stok = 47, Onay = true, KategoriId = 2 ,ishome=true, Image = "4.jpg"},
            new urun() {Id=5, Name = "Gold Kolye", Description = "Gold Detaylı Kadın Kolye", Fiyat = 320, Stok = 100, Onay = true, KategoriId = 3 ,ishome=true,Image="5.jpg"},
            new urun() {Id = 6,  Name = "Gümüş Kolye", Description = "Gümüş Detaylı Kadın Kolye", Fiyat = 320, Stok = 120, Onay = true, KategoriId = 3 , ishome = true, Image = "6.jpg"},
            new urun() {Id=7,Name = "Gold Küpe", Description = "Gold Detaylı Kadın Küpe", Fiyat = 125, Stok = 60, Onay = true, KategoriId = 4 ,ishome=true,Image="7.jpg"},
            new urun() {Id=8, Name = "Gümüş Küpe", Description = "Gümüş Detaylı Kadın Küpe", Fiyat = 125, Stok = 65, Onay = true, KategoriId = 4 , ishome = true, Image = "8.jpg"},
            new urun() {Id=9, Name = "Gold Halhal", Description = "Gold Detaylı Kadın Halhal", Fiyat = 50, Stok = 45, Onay = true, KategoriId = 5 ,ishome=true,Image="9.jpg"},
            new urun() {Id=10, Name = "Gümüş Halhal", Description = "Gümüş Detaylı Kadın Halhal", Fiyat = 50, Stok = 27, Onay = true, KategoriId = 5 , ishome = true, Image = "10.jpg"},
            new urun() {Id=11, Name = "Gold Şahmeran", Description = "Gold Detaylı Kadın Şahmeran", Fiyat = 175, Stok = 85, Onay = true, KategoriId = 6 ,ishome=true,Image="11.jpg"},
            new urun() {Id=12, Name = "Gümüş Şahmeran", Description = "Gümüş Detaylı Kadın Şahmeran", Fiyat = 175, Stok = 85, Onay = true, KategoriId = 6 , ishome = true, Image = "12.jpg"}

            };

            foreach (var urun in urunler)
            {
                context.uruns.Add(urun);

            }

            context.SaveChanges();


            base.Seed(context);
        }
    }
}