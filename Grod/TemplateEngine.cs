﻿/*
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
		Template _template;
		
		public TemplateEngine(Template template){
			if (template == null)
				throw new ArgumentNullException("template");
			
			_template = template;
		}
		
		public IEnumerable<HtmlPage> GenerateBlogroll(IEnumerable<BlogPost> posts)
		{
			
			
			
		}
	}
}
