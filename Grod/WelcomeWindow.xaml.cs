/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 03/05/2013
 * Time: 21:13
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;

namespace Grod
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        private readonly GrodDbContext _context = new GrodDbContext();
        private readonly BlogPostRepository _repo;

        public WelcomeWindow()
        {
            InitializeComponent();
            _repo = new BlogPostRepository(_context);
            GridPosts.DataContext = _repo;
        }

        void BtnNewPost_OnClick(object sender, RoutedEventArgs e)
        {
            var editor = new EditorWindow(new BlogPost()) { Owner = this, ShowActivated = true };
            editor.ShowDialog();
        }

        void BtnGenerateSite_OnClick(object sender, RoutedEventArgs e)
        {        	
            for (int i = 0; i < 10; i++)
            {
                _repo.AddPost(new BlogPost() { 
            	              	Title = "Test " + i,
            	              	BodyText = "Hello test\r\n=========\r\n" + i,
            	              	ShortUrl = "test-"+i 
            	              });
            }
            //_context.SaveChanges();
            
            var blog = new Blog("Developer MD", "Demonstration");
            
            var template = new Template("bootstrap");
            TemplateBlock block;
            List<TemplateBlock> blocks = new List<TemplateBlock>();
            
            block = TemplateBlock.FromObject(blog);
            block.AddPageType(BlogPageType.Any);
            blocks.Add(block);
            
            var engine = new TemplateEngine(template, blocks);
            
            var htmlPages = engine.GenerateHtmlPosts(_repo.Posts);
            
            FileHelper.CreateFiles(template, htmlPages);
        }
    }
}