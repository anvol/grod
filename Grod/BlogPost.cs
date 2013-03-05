/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 03/05/2013
 * Time: 22:39
 */
using System;
using System.Collections.Generic;

namespace Grod
{
	/// <summary>
	/// Description of BlogPost.
	/// </summary>
	public class BlogPost
	{
		private string _originalText;
		private string _markdownText;
		private string _htmlText;
		
		public string Title {get; set;}
		public string Body {get; set;}
		
		public List<BlogTag> Tags {get; private set;}
		
		/// <summary>
		/// When user started editing
		/// </summary>
		public DateTime Created{get;private set;}
		
		/// <summary>
		/// When published. Can be changed by user
		/// </summary>
		public DateTime Posted{get; set;}
		
		public BlogPost(){
			Created = DateTime.Now;
			Tags = new List<BlogTag>();
		}
		
		public void AddTag(BlogTag tag){
			if (!Tags.Contains(tag)) Tags.Add(tag);
		}
	}
}
