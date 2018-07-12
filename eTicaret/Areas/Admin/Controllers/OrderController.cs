using ETicModels.Entities;
using ETicRepository;
using System.Linq;
using System.Web.Mvc;

namespace eTicaret.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        UnitofWork uow;
        public OrderController()
        {
            uow = new UnitofWork();
        }
        public ActionResult List()
        {
            var list = uow.GetRepository<Order>().Listele();
            return View(list);
        }
        public ActionResult Update(int id)
        {
            Order o = uow.GetRepository<Order>().GetElementById(id);
            return View(o);
        }
        [HttpPost]
        public ActionResult Update(Order o)
        {
            uow.GetRepository<Order>().Guncelle(o);
            uow.SaveChanges();
            return Redirect("/Admin/Order/List");
        }
        public ActionResult OrderDetails(int id)
        {
            var list = uow.GetRepository<Order_Details>().Listele().Where(x => x.Order.OrderID == id);
            return View(list);
        }
    }
}