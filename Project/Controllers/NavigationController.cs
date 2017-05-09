using System.Web.Mvc;
using Test_Website.Repository;

namespace Test_Website.Controllers
{
    public class NavigationController : Controller
    {
        // TODO
        //private INavigationRepository Repository { get; }
        //public NavigationController(INavigationRepository navRep)
        //{
        //    this.Repository = navRep;
        //}
        public ActionResult MainNavigation()
        {
            NavigationRepository Repository = new NavigationRepository();
            return View("~/Views/Navigation/MainNavigation.cshtml", Repository.GetNavigationItems());
        }
    }
}