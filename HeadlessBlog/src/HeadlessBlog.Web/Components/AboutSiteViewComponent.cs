using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using HeadlessBlog.Web.Models;

namespace HeadlessBlog.Web.Components
{
    public class AboutSiteViewComponent : BaseViewComponent
    {
        public AboutSiteViewComponent(IOptions<AppSettings> settings, 
            IStringLocalizer<SharedResources> localizer) : base(settings, localizer)
        {
        }
    }
}
