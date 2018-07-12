using eTicaret.CustomAuthFltr;
using ETicModels.Entities;
using ETicRepository;
using System.Web.Mvc;

namespace eTicaret.Areas.Admin.Controllers
{

    [Auth(Role.Admin)]
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            using (UnitofWork uow = new UnitofWork())
            {
  var list = uow.GetRepository<Category>().Listele();
            return View(list);
            }
              
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category c)
        {
            using (UnitofWork uow = new UnitofWork())
            {
                uow.GetRepository<Category>().Ekle(c);
                uow.SaveChanges();
            }
            return Redirect("/Admin/Category/List");
        }
        public ActionResult Update(int id)
        {
            using (UnitofWork uow = new UnitofWork())
            {
                Category c = uow.GetRepository<Category>().GetElementById(id);
                return View(c);
            }

        }
        [HttpPost]
        public ActionResult Update(Category c)
        {
            using (UnitofWork uow = new UnitofWork())
            {
                uow.GetRepository<Category>().Guncelle(c);
                uow.SaveChanges();

            }
            return Redirect("/Admin/Category/List");
        }
        public ActionResult Delete(int id)
        {
            using (UnitofWork uow = new UnitofWork())
            {
                uow.GetRepository<Category>().Sil(id);
                uow.SaveChanges();

            }
            return Redirect("/Admin/Category/List");
        }
        //ProjectContext db;
        //public CategoryController()
        //{
        //    db = new ProjectContext();
        //}
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult List()
        //{
        //    List<Category> cat = db.Set<Category>().ToList();
        //        return View(cat);
        //}
        //public ActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Add(Category c)
        //{
        //    db.Set<Category>().Add(c);
        //    db.SaveChanges();
        //    return Redirect("/Admin/Category/List");
        //}
        //public ActionResult Update(int id)
        //{
        //    Category c = db.Set<Category>().Find(id);
        //    return View(c);
        //}
        //[HttpPost]
        //public ActionResult Update(Category c)
        //{
        //    db.Entry(c).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return Redirect("/Admin/Category/List");
        //}
        //public RedirectResult Delete(int id)
        //{
        //    var sil = db.Set<Category>().Find(id);
        //    db.Set<Category>().Remove(sil);
        //    db.SaveChanges();
        //    return Redirect("/Admin/Category/List");
        //}

    }
}