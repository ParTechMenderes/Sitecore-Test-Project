using System.Web.Mvc;
using Test_Website.Repository;

namespace Test_Website.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult MainNavigation()
        {
            NavigationRepository Repository = new NavigationRepository();
            return View("~/Views/Navigation/MainNavigation.cshtml", Repository.GetNavigationItems());
        }
    }
}