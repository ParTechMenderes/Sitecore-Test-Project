namespace Test_Website.Repository
{
    using Sitecore.Data.Items;
    using Test_Website.Models;
    public interface INewsRepository
    {
        NewsModel GetItems();
        void CreateItem(NewsFormModel model, TemplateItem template, Item parentItem);
        void PublishItem(Sitecore.Data.Items.Item item);
    }
}
