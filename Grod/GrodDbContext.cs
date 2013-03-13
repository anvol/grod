using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace Grod
{
    public class GrodDbContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }

        private ObservableCollection<BlogPost> _loadedPosts;
        public ObservableCollection<BlogPost> LoadedPosts
        {
            get
            {
                if (_loadedPosts == null)
                    _loadedPosts = new ObservableCollection<BlogPost>(Posts.Select(o => o));
                
                return _loadedPosts;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }    
}
