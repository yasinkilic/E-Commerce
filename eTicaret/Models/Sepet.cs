using ETicModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.Models
{
    public class Sepet
    {
        public Sepet()
        {
            Urunler = new List<Product>();
           
        }
        public List<Product> Urunler { get; set; }
        public double ToplamTutar { get { return Urunler.Sum(x => x.TotalPrice); } }
        public double ToplamTutarKdvli { get { return ToplamTutar * 0.18 + ToplamTutar; } }
        public ICollection<Order_Details> Order_Details { get; set; }
        public List<Order_Details> ToOrderDetails()
        {
           Sepet s = HttpContext.Current.Session["KullanıcıSepet"] as Sepet;
            List<Order_Details> list = new List<Order_Details>();
            Order_Details od = new Order_Details();
            foreach (var item in s.Urunler)
            {
                od.ProductName = item.ProductName;
                od.ProductID = item.ID;
                od.Quantity = item.Quantity;
                od.UnitPrice = item.Price;
                list.Add(od);
            }
            return list;
        }
    }
}