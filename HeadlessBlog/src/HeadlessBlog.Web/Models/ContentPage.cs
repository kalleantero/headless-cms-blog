using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadlessBlog.Web.Models
{
    public class ContentPage
    {
        public string NavigationTitle { get; set; }
        public string Title { get; set; }
        public string Media { get; set; }
        public string LeadContent { get; set; }
        public string BodyContent { get; set; }
        public string TopLeftContent { get; set; }
        public string TopRightContent { get; set; }
        public string BottomLeftContent { get; set; }
        public string BottomRightContent { get; set; }
    }
}
