using ETicModels.Entities;
using ETicRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eTicaret.CustomAuthFltr
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthAttribute : AuthorizeAttribute
    {

        private string[] UserProfilesRequired { get; set; }
        public AuthAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("roles");

            this.UserProfilesRequired = roles.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
        }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool authorized = false;
            UnitofWork uow = new UnitofWork();
            AppUser user = uow.GetRepository<AppUser>().Listele().First(x=>x.UserName==HttpContext.Current.User.Identity.Name);

            string userRole = Enum.GetName(typeof(Role), user.Role);

            foreach (var role in this.UserProfilesRequired)
            {
                if (userRole == role)
                {
                    authorized = true;
                    break;
                }
            }

            if (!authorized)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var logonUrl = url.Action("Http", "Error", new { Id = 401, Area = "" });
                filterContext.Result = new RedirectResult(logonUrl);
            }
            base.OnAuthorization(filterContext);
        }


    }
}
