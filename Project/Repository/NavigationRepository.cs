namespace Test_Website.Repository
{
    using Sitecore.Data.Items;
    using System.Collections.Generic;
    using Test_Website.Models;
    public class NavigationRepository : INavigationRepository
    {
        public NavigationModel GetNavigationItems()
        {
            // get master database
            Sitecore.Data.Database db = Sitecore.Configuration.Factory.GetDatabase("master");
            // get homepage
            Item homeItem = db.GetItem("/sitecore/content/Home");
            // new list
            List<Item> navList = new List<Item>();
            // add homepage
            navList.Add(homeItem);
            // add children of homepage if ShowInNavigation = true
            foreach (Item item in homeItem.GetChildren())
            {
                if (item["ShowInNavigation"] == "1")
                {
                    navList.Add(item);
                }
            }
            NavigationModel model = new NavigationModel()
            {
                Items = navList
            };
            return model;
        }
    }
}