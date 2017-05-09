using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.SecurityModel;
using Sitecore.Shell.Framework.Commands;
using System.Linq;
using System.Web.Mvc;
using Test_Website.Models;
using Test_Website.Repository;

namespace Test_Website.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult NewsList()
        {
            var dId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dSource = Sitecore.Context.Database.GetItem(dId);

            NewsModel model = new NewsModel()
            {
                Items = dSource.Children.ToList()
            };

            return View("~/Views/News/NewsList.cshtml", model);
        }
        public ActionResult CreateForm()
        {
            return View("~/Views/News/NewsCreate.cshtml");
        }
        [HttpPost]
        public ActionResult CreateForm(NewsFormModel model)
        {
            using (new SecurityDisabler())
            {
                // get master db
                Sitecore.Data.Database db = Sitecore.Configuration.Factory.GetDatabase("master");
                // get item template
                TemplateItem template = db.GetItem("/sitecore/templates/Features/News/_NewsArticle");
                // get current item parent
                Item parentItem = db.GetItem("/sitecore/content/Home/News");

                Item newItem = parentItem.Add(model.Title, template);
                try
                {

                    if (newItem != null && template != null)
                    {
                        newItem.Editing.BeginEdit();
                        newItem["NewsTitle"] = model.Title;
                        newItem["NewsContent"] = model.Content;
                        newItem.Editing.EndEdit();
                        // publish item
                        NewsRepository nRep = new NewsRepository();
                        nRep.PublishItem(newItem);
                    }
                }
                catch
                {
                    newItem.Editing.CancelEdit();
                }
            }
            return View("~/Views/News/NewsList.cshtml");
        }
    }
}