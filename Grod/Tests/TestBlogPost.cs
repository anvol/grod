/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 10.03.2013
 * Time: 20:21
 */
using System;
using System.Linq;
using System.Windows.Controls;
using NUnit.Framework;

namespace Grod
{
	[TestFixture]
	public class TestBlogPost
	{
		[Test]
		public void TestBodyHTML()
		{
			var post = new BlogPost(){
				BodyText = @"Test
======

Test2
-----"
			};
			
			string html = post.BodyHtml;
			
			Assert.AreEqual("<h1>Test</h1>\n<h2>Test2</h2>\n", html, "Markdown to html transformation is incorrect");
		}
		
		[Test]
		public void TestCreatedDate()
		{
			var now = DateTime.Now;
			var post = new BlogPost();
			
			var span = post.Created.Subtract(now);
			
			Assert.Greater(1, span.TotalSeconds, "Creation timestamp is incorrect");
		}
		
		[Test]
		public void TestDatabaseAddPost()
		{
			var post = new BlogPost(){Title = "TestDatabaseAddPost", BodyText = "Ignore this raw"};
			
			using(var db = new GrodDbContext()){
				db.Posts.Add(post);
				db.SaveChanges();

				int savedPost = db.Posts.Count(p => p.Id == post.Id);
				
				db.Posts.Remove(post);
				db.SaveChanges();
				
				Assert.AreEqual(1, savedPost, "Post save failed");
				
				savedPost = db.Posts.Count(p => p.Id == post.Id);
				
				Assert.AreEqual(0, savedPost, "Post delete failed");
			}
			
		}
	}
}
