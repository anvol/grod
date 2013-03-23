﻿/*
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
using System.Windows.Navigation;

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
		
		public IEnumerable<HtmlPage> GenerateBlogroll(IEnumerable<BlogPost> posts)
		{
			List<HtmlPage> pages = new List<HtmlPage>();
			int count = 0;
			int postPerPage = 10;
			int pageNum = 1;
			
			var blockBlogroll = blocks.FirstOrDefault(blocks => blocks.Name.ToLower() == "blogroll");
			var blockBlog = blocks.FirstOrDefault(blocks => blocks.Name.ToLower() == "blog");
			blockBlog.SetValue("Host", "");
			blockBlogroll.SetValue("Pagination", TemplateHelper.Pagination(posts.Count / postPerPage, pageNum));
			
			string blogrollHtmlBlock = TemplateHelper.GetBlockText(_template.LoadedTemplate, "Blogroll.Loop");
			StringBuilder pageBlogrollContent = new StringBuilder();
			
			string pageHtmlLoopBlock = "";
			foreach (var post in posts){
				count++;
				
				pageHtmlLoopBlock += TemplateHelper.ReplaceTagWithData(blogrollHtmlBlock, post);
				
				if (count==10){
					count = 0;
					pageNum++;
					blockBlogroll.SetValue("Pagination", TemplateHelper.Pagination(posts.Count / postPerPage, pageNum));
					
					string postTemplate = _template.LoadedTemplate;
					postTemplate = TemplateHelper.RemoveUsedBlockTags(postTemplate, blocks, BlogPageType.Blogroll);
					foreach(var block in blocks){
						postTemplate = TemplateHelper.ReplaceTagWithData(postTemplate, block);
					}
					
					postTemplate = TemplateHelper.ReplaceBlockWithData(postTemplate, "Blogroll.Loop", pageHtmlLoopBlock);
					
					yield return new HtmlPage(postTemplate, "page-"+pageNum);
				}
			}
		}
		
		public IEnumerable<HtmlPage> GenerateHtmlPosts(IEnumerable<BlogPost> posts)
		{
			// prepare template for post pages
			string postTemplate = TemplateHelper.RemoveUnusedBlocks(_template.LoadedTemplate, blocks, BlogPageType.Post);
			var blockBlog = blocks.FirstOrDefault(blocks => blocks.Name.ToLower() == "blog");
			blockBlog.SetValue("Host", "../");
			
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
