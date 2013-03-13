using System;
using System.Collections.Generic;

namespace Grod
{
    public interface IBlogPostRepository
    {
        void AddPost(BlogPost post);
        void RemovePost(Guid guidPost);
        IEnumerable<BlogPost> GetAllPosts();
        BlogPost GetPostByGuid(Guid guidPost);
    }
}