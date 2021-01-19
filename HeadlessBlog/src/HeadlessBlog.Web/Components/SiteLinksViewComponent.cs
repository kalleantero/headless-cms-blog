using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using HeadlessBlog.Web.Models;

namespace HeadlessBlog.Web.Components
{
    public class SiteLinksViewComponent : TopNavigationViewComponent
    {
        public SiteLinksViewComponent(IOptions<AppSettings> settings, 
            IStringLocalizer<SharedResources> localizer) : base(settings, localizer)
        {

        }        
    }
}
