using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using deneme.Entity;

namespace deneme.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        public List<CartLine> CartLines { get {  return _cartLines; } }


        public void AddProduct(urun product,int quantity)
        {
            var line=_cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if(line == null)
            {
                _cartLines.Add(new CartLine() {Product=product,Quantity=quantity });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public void DeleteProduct(urun product) 
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);

        }

        public double Total()
        {
            return _cartLines.Sum(i =>i.Product.Fiyat* i.Quantity);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }


    }

    public class CartLine
    {
        public urun Product { get; set; }
        public int Quantity {  get; set; }
    }
}