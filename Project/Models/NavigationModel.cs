using Sitecore.Data.Items;
using System.Collections.Generic;

namespace Test_Website.Models
{
    public class NavigationModel
    {
        public IEnumerable<Item> Items { get; set; }
    }
}