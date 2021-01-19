using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ButterCMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using HeadlessBlog.Web.Constants;
using HeadlessBlog.Web.Models;

namespace HeadlessBlog.Web.Controllers
{
    public class ButterCmsController : Controller
    {
        private ButterCMSClient _cmsClient;
        private readonly AppSettings _appSettings;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ButterCmsController(IOptions<AppSettings> settings, IStringLocalizer<SharedResources> localizer)
        {
            _appSettings = settings.Value;
            _localizer = localizer;

            if (!string.IsNullOrEmpty(_appSettings.ButterCmsApiKey))
            {
                _cmsClient = new ButterCMSClient(_appSettings.ButterCmsApiKey);
            }
        }

        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "s" })]
        [Route("search/{s?}")]
        public IActionResult Search(string s)
        {
            if(string.IsNullOrEmpty(s)) return View();

            ViewBag.BlogTitle = _appSettings.HeaderBlogTitle;
            ViewBag.AboutTheSiteDescription = _localizer["AboutTheSiteContent"]; 

            var dataResponse = _cmsClient?.SearchPosts(s, int.MinValue, int.MaxValue);             
            return View(CommonConstants.Views.Index, dataResponse?.Data?.OrderByDescending(x => x.Published).ToList());
        }

        [ResponseCache(Duration = 3600)]
        public IActionResult Index()
        {
            ViewBag.BlogTitle = _appSettings.HeaderBlogTitle;
            ViewBag.AboutTheSiteDescription = _localizer["AboutTheSiteContent"];
            
            var dataResponse = _cmsClient?.ListPosts(int.MinValue, int.MaxValue, true, null, null, null);

            return View(dataResponse?.Data?.OrderByDescending(x => x.Published).ToList());
        }

        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "slug" })]
        [Route("blog/{slug}")]
        public async Task<ActionResult> ShowPost(string slug)
        {
            ViewBag.BlogTitle = _appSettings.HeaderBlogTitle;

            if (string.IsNullOrEmpty(slug)) return View(CommonConstants.Views.Post);

            var postResponse = await _cmsClient?.RetrievePostAsync(slug);
            
            return View(CommonConstants.Views.Post, postResponse);
        }

        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "slug" })]
        [Route("{slug}")]
        public async Task<ActionResult> ShowPage(string slug)
        {
            ViewBag.BlogTitle = _appSettings.HeaderBlogTitle;

            if (string.IsNullOrEmpty(slug)) return View(CommonConstants.Views.ContentPage);

            if (string.IsNullOrEmpty(_appSettings.ContentPageName))
                return View(CommonConstants.Views.ContentPage);

            var parameterDict = new Dictionary<string, string>();
            var pageResponse = await _cmsClient?.RetrievePageAsync<ContentPage>(_appSettings.ContentPageName, slug, parameterDict);

            return View(CommonConstants.Views.ContentPage, pageResponse?.Data);
        }

        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "slug" })]
        [Route("blog/category/{slug}")]
        public async Task<ActionResult> ShowPostsByCategory(string slug)
        {
            ViewBag.BlogTitle = _appSettings.HeaderBlogTitle;
            ViewBag.AboutTheSiteDescription = _localizer["AboutTheSiteContent"];

            if (string.IsNullOrEmpty(slug)) return View(CommonConstants.Views.Index);

            var dataResponse = await _cmsClient?.ListPostsAsync(int.MinValue, int.MaxValue, true, null, slug, null);         
          
            return View(CommonConstants.Views.Index, dataResponse?.Data?.OrderByDescending(x => x.Published).ToList());
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
