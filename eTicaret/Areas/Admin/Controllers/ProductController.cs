using ETicModels.Entities;
using System.Web.Mvc;
using eTicaret.CustomAuthFltr;
using ETicRepository;
using System.Web;
using System.Web.Helpers;
using System.IO;
using System;

namespace eTicaret.Areas.Admin.Controllers
{
    [Auth(Role.Admin)]
    public class ProductController : Controller
    {
        UnitofWork uow;
        public ProductController()
        {
            uow = new UnitofWork();
        }
        public ActionResult Add()
        {
            var list = uow.GetRepository<Category>().Listele();
         
            return View(list);
        }
        [HttpPost]
        public ActionResult Add(Product p, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File!=null)
                {
                    WebImage img = new WebImage(File.InputStream);
                    FileInfo fileinfo = new FileInfo(File.FileName);

                    string newfile = Guid.NewGuid().ToString() + fileinfo.Extension;
                    img.Resize(582, 640);
                    img.Save("~/Content/Images/" + newfile);
                    p.ImagePath = "/Content/Images/" + newfile;
                }

                uow.GetRepository<Product>().Ekle(p);
                uow.SaveChanges();
            }

            return Redirect("/Admin/Product/List");
        }
        public ActionResult List()
        {
            var list = uow.GetRepository<Product>().Listele();
            return View(list);
        }
        public ActionResult Delete(int id)
        {
            uow.GetRepository<Product>().Sil(id);
            uow.SaveChanges();

            return Redirect("/Admin/Product/List");
        }
        public ActionResult Update(int id)
        {
            Product c = uow.GetRepository<Product>().GetElementById(id);
            

            return View(c);
        }
        [HttpPost]
        public ActionResult Update(Product p,HttpPostedFileBase File)
        {
            
           var asileleman=uow.GetRepository<Product>().GetElementById(p.ID);
            asileleman.ProductName = p.ProductName;
            asileleman.Description = p.Description;
            asileleman.UnitsInStock = p.UnitsInStock;
            asileleman.Price = p.Price;

                if (File != null)
                {
                    WebImage img = new WebImage(File.InputStream);
                    FileInfo fileinf = new FileInfo(File.FileName);

                    string newfile = Guid.NewGuid().ToString() + fileinf.Extension;
                    img.Resize(270, 180);
                    img.Save("~/Content/Images/" + newfile);
                    asileleman.ImagePath = "/Content/Images/" + newfile;
                }
             
                uow.GetRepository<Product>().Guncelle(asileleman);
                uow.SaveChanges();
                

            return Redirect("/Admin/Product/List");
        }
        
       
       
    }
}