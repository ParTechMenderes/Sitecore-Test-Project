namespace Test_Website.Controllers
{
    using Sitecore.Data.Items;
    using System.Web.Mvc;
    using Test_Website.Models;
    using Test_Website.Repository;
    public class NewsController : Controller
    {        
        private INewsRepository Repository { get; }
        public NewsController(INewsRepository newsRepository)
        {
            this.Repository = newsRepository;
        }
        public ActionResult NewsList()
        {
            return View("~/Views/News/NewsList.cshtml", this.Repository.GetItems());
        }
        public ActionResult CreateForm()
        {
            return View("~/Views/News/NewsCreate.cshtml");
        }
        [HttpPost]
        public ActionResult CreateForm(NewsFormModel model)
        {
            // get master db
            Sitecore.Data.Database db = Sitecore.Configuration.Factory.GetDatabase("master");
            // get item template
            TemplateItem template = db.GetItem("/sitecore/templates/Project/Page types/News article");
            // get current item parent
            Item parentItem = db.GetItem("/sitecore/content/Home/News");
            this.Repository.CreateItem(model, template, parentItem);
            return View("~/Views/News/NewsCreate.cshtml");
        }
    }
}