using eTicaret.Models;
using ETicModels.Entities;
using ETicRepository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eTicaret.Controllers
{
    public class SiparisController : Controller
    {
        public ActionResult Order(int id)
        {
            Order_Details od = new Order_Details();
            using (UnitofWork uow = new UnitofWork())
            {
               var urun = uow.GetRepository<Product>().GetElementById(id);
                od.ProductName = urun.ProductName;
                od.ProductID = urun.ID;
                od.Quantity++;
                od.UnitPrice = urun.Price;
                Session.Add("od", od);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Order(Order o)
        {
            var odt = Session["od"] as Order_Details;
            Order_Details od = new Order_Details();
            od = odt;
            od.Order = o;
            o.Order_Details.Add(od);
            using (UnitofWork uow = new UnitofWork())
            {
                uow.GetRepository<Order>().Ekle(o);
                uow.GetRepository<Order_Details>().Ekle(od);
                uow.SaveChanges();
            }
            Response.Write("<script>alert('Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz')</script>");
            return Redirect("/Home/Index");         
        }
        public ActionResult OrderCart()
        {
            Sepet s = new Sepet();
            var odlist= s.ToOrderDetails();
            Session.Add("odlist", odlist);
            return View();
        }
        [HttpPost]
        public ActionResult OrderCart(Order o)
        {
            List<Order_Details> odlist = Session["odlist"] as List<Order_Details>;
            foreach (var item in odlist)
            {
                item.Order = o;
                o.Order_Details.Add(item);
            }
            using(UnitofWork uow = new UnitofWork())
            {
                foreach (var item in odlist)
                {
                    uow.GetRepository<Order_Details>().Ekle(item);
                }
                uow.GetRepository<Order>().Ekle(o);
            }
            Response.Write("<script>alert('Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz')</script>");
            return View("/Home/Index");
        }
    }
}