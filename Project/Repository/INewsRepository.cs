using Sitecore.Data.Items;
using Test_Website.Models;

namespace Test_Website.Repository
{
    public interface INewsRepository
    {
        NewsModel GetItems();
        void CreateItem(NewsFormModel model, TemplateItem template, Item parentItem);
        void PublishItem(Sitecore.Data.Items.Item item);
    }
}
