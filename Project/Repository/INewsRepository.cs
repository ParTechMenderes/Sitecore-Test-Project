using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Website.Models;

namespace Test_Website.Repository
{
    public interface INewsRepository
    {
        List<Item> GetItems();
        void CreateItem(NewsFormModel model, TemplateItem template, Item parentItem);
        void PublishItem(Sitecore.Data.Items.Item item);
    }
}
