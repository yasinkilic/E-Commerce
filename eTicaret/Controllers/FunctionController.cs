using ETicModels.Entities;
using ETicRepository;
using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eTicaret.Controllers
{

    public class FunctionController : Controller
    {
      
        [HttpPost]
        public JsonResult Search(string a)
        {
            using(UnitofWork uow = new UnitofWork())
            {
                var list = uow.GetRepository<Product>().Listele().Where(x => x.ProductName.ToLower().StartsWith(a) || x.ProductName.ToLower().Contains(a)).Select(x => new Product
                {
                    ID = x.ID,
                    ImagePath = x.ImagePath,
                    ProductName = x.ProductName
                });
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult SiparisTasarimSonucu(string dt)
        {
            using(UnitofWork uow=new UnitofWork())
            {
                var urun = uow.GetRepository<Product>().Listele().Select(x=> new Product{
               ID=x.ID,
               ImagePath=x.ImagePath,
               ProductName=x.ProductName
                }).First(x => x.ProductName == dt);
           
             
                return Json(urun, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult ListByCat(int id,int page=1)
        {
            using (UnitofWork uow = new UnitofWork())
            {
                return View(uow.GetRepository<Product>().Listele().Where(x => x.CategoryID == id).ToPagedList(page, 9));
            }
        }
    }
}
