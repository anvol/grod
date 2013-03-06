﻿/*
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
		public string BodyText {get; set;}
		
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
		}

	    public string BodyHtml
	    {
	        get { var md = new MarkdownDeep.Markdown {ExtraMode = true};
	            return md.Transform(BodyText);
	        }
	    }
	}
}