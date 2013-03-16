/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 16.03.2013
 * Time: 12:34
 */
using System;
using System.Collections.Generic;

namespace Grod
{
	/// <summary>
	/// Block-placeholder in template
	/// </summary>
	public class TemplateBlock
	{
		protected Dictionary<string, string> props;
		protected HashSet<BlogPageType> validPageTypes;
		
		public virtual string Name {get; set;}
		
		public bool CanBeUsed(BlogPageType type)
		{
			return validPageTypes.Contains(type) || validPageTypes.Contains(BlogPageType.Any);
		}
		
		public TemplateBlock(string name){
			validPageTypes = new HashSet<BlogPageType>();
			props = new Dictionary<string, string>();
			Name = name;
		}
		
		public virtual TemplateBlock AddPageType(BlogPageType type){
			validPageTypes.Add(type);
			return this;
		}
		
		public virtual string GetValue(string propName){
			if (props.ContainsKey(propName.ToLower()))return props[propName.ToLower()];
			return "";
		}
		
		public virtual TemplateBlock AddValue(string propertieName, string propertieValue){
			props.Add(propertieName.ToLower(), propertieValue);
			return this;
		}
	}
}
