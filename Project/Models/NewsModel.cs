using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Website.Models
{
    public class NewsModel
    {
        public IEnumerable<Item> Items { get; set; }
    }
}