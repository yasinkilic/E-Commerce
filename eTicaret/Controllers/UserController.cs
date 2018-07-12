using ETicModels.Entities;
using ETicRepository;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace eTicaret.Controllers
{
    public class UserController : Controller
    {
         UnitofWork uow;
        public UserController()
        {
            uow = new UnitofWork();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser a)
        {

            AppUser data = uow.GetRepository<AppUser>().Listele().First(x => x.UserName == a.UserName && x.Password == a.Password);

            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(data.UserName, true);
                HttpCookie usercookie = new HttpCookie("user", data.UserName.ToString());
                usercookie.Expires.AddMinutes(20);
                Response.Cookies.Add(usercookie);

                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
        public ActionResult Exit()
        {
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpCookie c = new HttpCookie("user");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
            return Redirect("/Home/Index");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUser a, HttpPostedFileBase file)
        {
            if (uow.GetRepository<AppUser>().Listele().Any(x => x.UserName == a.UserName || x.Email == a.Email))
            {

                return RedirectToAction("Index", "Home");
            }


            else
            {
                if (file != null)
                {
                    WebImage img = new WebImage(file.InputStream);
                    FileInfo fileInfo = new FileInfo(file.FileName);

                    string newfile = Guid.NewGuid().ToString() + fileInfo.Extension;
                    img.Resize(400, 500);
                    img.Save("~/Content/Images/" + newfile);
                    a.ImagePath = "/Content/Images/" + newfile;
                }


                a.Role = Role.Admin;
                uow.GetRepository<AppUser>().Ekle(a);
                uow.SaveChanges();
                return Redirect("/User/Login");
            }

        }
        

    }
}