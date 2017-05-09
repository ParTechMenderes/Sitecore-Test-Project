using Sitecore.Data;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using Test_Website.Models;
using Sitecore.Mvc.Presentation;

namespace Test_Website.Repository
{

    public class NewsRepository : INewsRepository
    {
        public List<Item> GetItems() {
            var dId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dSource = Sitecore.Context.Database.GetItem(dId);
            return dSource.Children.ToList();
        }
        public void CreateItem(NewsFormModel model, TemplateItem template, Item parentItem) {
            using (new SecurityDisabler())
            {
                // add item
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
                        PublishItem(newItem);
                    }
                }
                catch
                {
                    newItem.Editing.CancelEdit();
                }
            }
        }
        public void PublishItem(Item item)
        {
            // The publishOptions determine the source and target database,
            // the publish mode and language, and the publish date
            Sitecore.Publishing.PublishOptions publishOptions =
              new Sitecore.Publishing.PublishOptions(item.Database,
                                                     Database.GetDatabase("web"),
                                                     Sitecore.Publishing.PublishMode.SingleItem,
                                                     item.Language,
                                                     System.DateTime.Now);  // Create a publisher with the publishoptions
            Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);

            // Choose where to publish from
            publisher.Options.RootItem = item;

            // Publish children as well?
            publisher.Options.Deep = true;

            // Do the publish!
            publisher.Publish();
        }
    }
}