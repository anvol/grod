using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Grod
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly GrodDbContext _context;
        private readonly ObservableCollection<BlogPost> _posts;

        public BlogPostRepository()
        {
            _context = new GrodDbContext();

            _posts = new ObservableCollection<BlogPost>(GetAllPosts());
        }

        public BlogPostRepository(GrodDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;

            _posts = new ObservableCollection<BlogPost>(GetAllPosts());
        }

        public void AddPost(BlogPost post)
        {
            _context.Posts.Add(post);
            _posts.Add(post);
        }

        public void RemovePost(Guid guidPost)
        {
            var post = GetPostByGuid(guidPost);
            _context.Posts.Remove(post);
            _posts.Remove(post);
        }

        public IEnumerable<BlogPost> GetAllPosts()
        {
            return _context.Posts.Select(p => p);
        }

        public ObservableCollection<BlogPost> Posts
        {
            get
            {
                return _posts;
            }
        }

        public BlogPost GetPostByGuid(Guid guidPost)
        {
            return _context.Posts.First(p => p.Id == guidPost);
        }
    }
}