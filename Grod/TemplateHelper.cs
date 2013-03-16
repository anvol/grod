using System.Collections.Generic;
using System.Text;

/*
 * User: Andrey
 * Date: 16.03.2013
 * Time: 15:36
 */

namespace Grod
{
	public static class TemplateHelper
	{
		/// <summary>
		/// Removes all blocks that is not used in current page type
		/// </summary>
		/// <param name="template">Base template</param>
		/// <param name="blocks">Available blocks</param>
		/// <param name="type">Type of page to generate template for</param>
		/// <returns>Cleaned template</returns>
		public static string RemoveUnusedBlocks(string template, IEnumerable<TemplateBlock> blocks, BlogPageType type)
		{
			foreach(var block in blocks){
				if (block.CanBeUsed(type)) continue;
				
				int posOpen = 0;
				int posClose = 0;
				string openTag = string.Format("{{{0}}}", block.Name);
				string closeTag = string.Format("{{/{0}}}", block.Name);
				while (posOpen!=-1) {
					// find open tag
					posOpen = template.IndexOf(openTag, posOpen);
					if (posOpen==-1) break;
					posClose = template.IndexOf(closeTag, posOpen);
					
					if (posOpen < posClose) template = template.Remove(posOpen, posClose-posOpen+closeTag.Length);
				}
			}
			
			return template;
		}
		
		
		public static string RemoveUsedBlockTags(string template, IEnumerable<TemplateBlock> blocks, BlogPageType type){
			foreach (var block in blocks) {
				if (!block.CanBeUsed(type)) continue;
				string openTag = string.Format("{{{0}}}", block.Name);
				string closeTag = string.Format("{{/{0}}}", block.Name);
				
				template = template.Replace(openTag, "");
				template = template.Replace(closeTag, "");
			}
			
			return template;
		}
		
		public static string ReplaceTagWithData(string template, TemplateBlock block){
			// Example: {Blog.Title}
			StringBuilder sb = new StringBuilder(template);
			int position = 0;
			int closingBrace = 0;
			string tag = string.Format("{{{0}.", block.Name); // {Blog.
			while (position != -1) {
				position = template.IndexOf(tag, position);
				if (position == -1) break;
				closingBrace = template.IndexOf("}", position);
				if (closingBrace == -1) break;
				
				position+=tag.Length; // tag offset
				string property = template.Substring(position, closingBrace - position); // Title
				string propertyData = block.GetValue(property);
				
				sb.Replace(tag + property + "}", propertyData);
			}
			
			return sb.ToString();
		}
	}
}