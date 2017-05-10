namespace Test_Website.Models
{
    using Sitecore.Data.Items;
    using System.Collections.Generic;
    public class NavigationModel
    {
        public IEnumerable<Item> Items { get; set; }
    }
}