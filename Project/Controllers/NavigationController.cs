namespace Test_Website.Controllers
{
    using System.Web.Mvc;
    using Test_Website.Repository;
    public class NavigationController : Controller
    {
        private INavigationRepository Repository { get; }
        public NavigationController(INavigationRepository navRepository)
        {
            this.Repository = navRepository;
        }
        public ActionResult MainNavigation()
        {
            return View("~/Views/Navigation/MainNavigation.cshtml", this.Repository.GetNavigationItems());
        }
    }
}