using eTicaret.Models;
using ETicContext;
using ETicModels.Entities;
using ETicRepository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eTicaret.Controllers
{
    public class HomeController : Controller
    {
        UnitofWork uow;
        public HomeController()
        {
            uow = new UnitofWork();
        }
        public ActionResult Index(int page = 1)
        {
            
               var list = uow.GetRepository<Product>().Listele();
            return View(list.OrderBy(x => x.ProductName).ToPagedList(page, 16));
                
        }
        public ActionResult SiparisTasarla()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
           
                Product urunDetay = uow.GetRepository<Product>().GetElementById(id);
            urunDetay.Category = uow.GetRepository<Category>().GetElementById(urunDetay.CategoryID);
                var comments = uow.GetRepository<Comment>().Listele().Where(x => x.ProductID == id);
                if (comments.Count() > 0)
                {
                    urunDetay.Comments.AddRange(comments);
                    return View(urunDetay);
                }
                else
                {
                    return View(urunDetay);
                }
          
        }
        [HttpPost]
        public JsonResult RandomProducts(int id)
        {
            var productlar = uow.GetRepository<Product>().Listele().Where(x => x.CategoryID == id);
            var elemansayisi = productlar.Count();
            var list = new List<Product>(4);
           var list2= productlar.ToList();
            for (int i = 0; i < 4; i++)
            {
                Random rnd = new Random();
                var sayi = rnd.Next(1,elemansayisi);
                if (list.Contains(list2[sayi]))
                {
                    sayi = rnd.Next(1, elemansayisi);
                    list.Add(list2[sayi]);

                }
                else
                {
                    list.Add(list2[sayi]);
                }



            }
           var products= list.Select(x => new Product
            {
                ID = x.ID,
                ProductName = x.ProductName,
                ImagePath = x.ImagePath,
                Price = x.Price
            });
            return Json(products,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Comment(int id,Comment c)
        {
                var p = uow.GetRepository<Product>().GetElementById(id);
                c.Product = p;
                c.ProductID = id;
                uow.GetRepository<Comment>().Ekle(c);
                uow.SaveChanges();
                return Redirect("/Home/Details/" + id);
        }

        public ActionResult CategoryList()
        {
           
                var list = uow.GetRepository<Category>().Listele();
                return View(list);
           
        }
        public ActionResult AddtoCart(int id)
        {
           
            if (Session["KullanıcıSepet"] != null)
              {
                    Sepet sepet = Session["KullanıcıSepet"] as Sepet;
                    Product p = uow.GetRepository<Product>().GetElementById(id);
                if (sepet.Urunler.Any(x=>x.ID==p.ID))
                {
                    var eleman = sepet.Urunler.First(x => x.ID == p.ID);
                    eleman.Quantity += 1;
                    return View("Cart", sepet);
                }
                else
                {
                    p.Quantity += 1;
                    sepet.Urunler.Add(p);
                    return View("Cart", sepet);
                }
             }
            else
                {
                    Sepet sepet = new Sepet();
                    Product p = uow.GetRepository<Product>().GetElementById(id);
                    p.Quantity += 1;
                    sepet.Urunler.Add(p);
                    Session.Add("KullanıcıSepet", sepet);
                    return View("Cart", sepet);
                }
                
        }
        public ActionResult Cart()
        {
            if (Session["KullanıcıSepet"] != null)
            {
               var sepet= Session["KullanıcıSepet"] as Sepet;
                return View(sepet);
            }
            else
            {
                var _sepet = new Sepet();
                Session.Add("KullanıcıSepet", _sepet);
                return View(_sepet);
            }
        }
        public ActionResult Delete(int id)
        {
           Sepet _list = Session["KullanıcıSepet"] as Sepet;
            var silinecekeleman = _list.Urunler.Find(x => x.ID == id);
            _list.Urunler.Remove(silinecekeleman);
           return View("Cart", _list);
        }
    }
}