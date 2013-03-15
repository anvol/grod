using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Grod
{
    /// <summary>
    /// Presents general information about blog
    /// </summary>
    public class Blog
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Blogroll { get; private set; }

        public Blog(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void SetRecentPosts(IEnumerable<BlogPost> recentPosts)
        {
            var sb = new StringBuilder();
            foreach (var post in recentPosts)
            {
                sb.AppendFormat("<li class=\"link-post-recent\"><a href=\"{0}\">{1}</a></li>\r\n", 
                    Uri.EscapeUriString(post.ShortUrl), 
                    WebUtility.HtmlEncode(post.Title));
            }
            Blogroll = sb.ToString();
        }
    }
}
