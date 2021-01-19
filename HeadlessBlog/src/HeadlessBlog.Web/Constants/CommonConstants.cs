
namespace HeadlessBlog.Web.Constants
{
    /// <summary>
    /// Common constants.
    /// </summary>
    public static class CommonConstants
    {
        public static class ButterCms
        {
            public static readonly string ButterCmsApiKey = "ButterCmsApiKey";
        }

        public static class CacheKeys
        {
            public static readonly string AllPosts = "AllPosts";
            public static readonly string ShowPost = "ShowPost";
            public static readonly string ShowPage = "ShowPage";
            public static readonly string ShowPostsByCategory = "ShowPostsByCategory";
            public static readonly string Navigation = "Navigation";
            public static readonly string SocialLinks = "SocialLinks";
            public static readonly string Search = "Search";
        }

        public static class Views
        {
            public static readonly string Index = "Index";
            public static readonly string ContentPage = "ContentPage";
            public static readonly string Post = "Post";
        }

        public static class Routes
        {
            public static readonly string Category = "/blog/category/";
            public static readonly string Blog = "/blog/";
        }
    }
}
