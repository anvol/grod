/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 16.03.2013
 * Time: 12:37
 */
using System;
using System.Collections.Generic;

namespace Grod
{
	/// <summary>
	/// Description of TemplateEngine.
	/// </summary>
	public class TemplateEngine
	{
		protected Template _template;
		protected Dictionary<string, PropertieBag> blocks;		
		
		public TemplateEngine(Template template, IEnumerable<PropertieBag> blocks){
			if (template == null)
				throw new ArgumentNullException("template");
			
			_template = template;
			this.blocks = new Dictionary<string, PropertieBag>();
			foreach(var block in blocks) this.blocks.Add(block.Name, block);
		}
		
		public IEnumerable<HtmlPage> GenerateBlogroll(IEnumerable<BlogPost> posts)
		{
			List<HtmlPage> pages = new List<HtmlPage>();
			int count = 0;
			foreach (var post in posts){
				
			}
			
			throw new NotImplementedException();
		}
	}
}
