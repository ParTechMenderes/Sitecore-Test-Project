using Sitecore.Data.Items;
using System.Web.Mvc;
using Test_Website.Models;
using Test_Website.Repository;

namespace Test_Website.Controllers
{
    public class NewsController : Controller
    {
        // TODO get repository
        //private INewsRepository Repository { get; }
        //public NewsController(INewsRepository newsRep)
        //{
        //    this.Repository = newsRep;
        //}
        public ActionResult NewsList()
        {
            NewsRepository Repository = new NewsRepository();
            return View("~/Views/News/NewsList.cshtml", Repository.GetItems());
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
            TemplateItem template = db.GetItem("/sitecore/templates/Features/News/_NewsArticle");
            // get current item parent
            Item parentItem = db.GetItem("/sitecore/content/Home/News");
            NewsRepository Repository = new NewsRepository();
            Repository.CreateItem(model, template, parentItem);
            return View("~/Views/News/NewsCreate.cshtml");
        }
    }
}