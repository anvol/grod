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
		public PropertieBag(string blockName){
			BlockName = blockName;
		}
		
		public virtual string BlockName {get; set;}
		
		protected Dictionary<string, string> props;
		
		public virtual string GetValue(string propName){
			if (props.ContainsKey(propName))return props[propName];
			return "";
		}
		
		public virtual void AddValue(string propertieName, string propertieValue){
			props.Add(propertieName, propertieValue);
		}
	}
}
