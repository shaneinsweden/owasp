using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoShop.Models
{
    public class Movie
    {
        public List<string> Languages { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SelectedLanguage { get; set; }

        public string Summary { get; set; }

        public Movie()
        {
            Languages = new List<string>() { "Swedish", "English" };
        }
    }
}