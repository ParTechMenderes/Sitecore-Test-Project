using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Website.Models
{
    public class NewsFormModel
    {
        //todo [Required]
        public string Title { get; set; }
        //todo [Required]
        public string Content { get; set; }
    }
}