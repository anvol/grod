using System.Collections.Generic;
/*
 * User: Andrey
 * Date: 16.03.2013
 * Time: 15:36
 */

namespace Grod
{
	public static class TemplateHelper
	{
		public static string RemoveUnusedBlocks(string template, IEnumerable<PropertieBag> blocks, BlogPageType type)
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
	}
}