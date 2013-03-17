/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 16.03.2013
 * Time: 12:37
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grod
{
	/// <summary>
	/// Description of TemplateEngine.
	/// </summary>
	public class TemplateEngine
	{
		protected Template _template;
		protected List<TemplateBlock> blocks;		
		
		public TemplateEngine(Template template, IEnumerable<TemplateBlock> blocks){
			if (template == null)
				throw new ArgumentNullException("template");
			
			_template = template;
			this.blocks = new List<TemplateBlock>();
			this.blocks.AddRange(blocks);
		}
		
		public IEnumerable<HtmlPage> GenerateBlogroll(string template, IEnumerable<BlogPost> posts)
		{
			List<HtmlPage> pages = new List<HtmlPage>();
			int count = 0;
			int pageNum = 1;
			
			var blockBlogroll = blocks.FirstOrDefault(blocks => blocks.Name.ToLower() == "blogroll");
			
			string blogrollHtmlBlock = TemplateHelper.GetBlockText(template, "Blogroll.Loop");
			StringBuilder pageBlogrollContent = new StringBuilder();
			
			foreach (var post in posts){
				
			}
			
			throw new NotImplementedException();
		}
		
		public IEnumerable<HtmlPage> GenerateHtmlPosts(IEnumerable<BlogPost> posts)
		{
			// prepare template for post pages
			string postTemplate = TemplateHelper.RemoveUnusedBlocks(_template.LoadedTemplate, blocks, BlogPageType.Post);
			
			foreach(var post in posts) yield return PostPage(postTemplate, post);
		}
		
		private HtmlPage PostPage(string postTemplate, BlogPost post){
			foreach(var block in blocks){
				postTemplate = TemplateHelper.ReplaceTagWithData(postTemplate, block);
			}
			
			postTemplate = TemplateHelper.ReplaceTagWithData(postTemplate, post.GetTemplateBlock());
			postTemplate = TemplateHelper.RemoveUsedBlockTags(postTemplate, blocks, BlogPageType.Post);
			postTemplate = TemplateHelper.RemoveUsedBlockTags(postTemplate, post.GetTemplateBlock(), BlogPageType.Post);
			
			return new HtmlPage(postTemplate, post.ShortUrl);
		}
	}
}
