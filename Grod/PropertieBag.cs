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
	public class PropertieBag
	{
		protected Dictionary<string, string> props;
		protected HashSet<BlogPageType> validPageTypes;
		
		public virtual string Name {get; set;}
		
		public bool CanBeUsed(BlogPageType type)
		{
			return validPageTypes.Contains(type);
		}
		
		public PropertieBag(string blockName){
			validPageTypes = new HashSet<BlogPageType>();
			Name = blockName;
		}
		
		public virtual PropertieBag AddPageType(BlogPageType type){
			validPageTypes.Add(type);
			return this;
		}
		
		public virtual string GetValue(string propName){
			if (props.ContainsKey(propName))return props[propName];
			return "";
		}
		
		public virtual PropertieBag AddValue(string propertieName, string propertieValue){
			props.Add(propertieName, propertieValue);
			return this;
		}
	}
}
