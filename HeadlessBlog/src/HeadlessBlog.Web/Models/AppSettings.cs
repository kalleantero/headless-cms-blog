namespace HeadlessBlog.Web.Models
{
    public class AppSettings
    {
        public string ContentPageName { get; set; }    
        public string AuthorSlug { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; } 
        public string GithubUrl { get; set; }
        public string ButterCmsApiKey { get; set; }
        public string FooterCopyright { get; set; }
        public string HeaderBlogTitle { get; set; }
    }
}
