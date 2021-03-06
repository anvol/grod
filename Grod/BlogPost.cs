﻿/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 03/05/2013
 * Time: 22:39
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grod
{
	/// <summary>
	/// Description of BlogPost.
	/// </summary>
	[BlockValue("Post")]
	public class BlogPost
	{
        [Key]
        public Guid Id { get; private set; }

        [BlockValue("Title")]
		public string Title {get; set;}
		
		[BlockValue("Body")]
		public string BodyText {get; set;}
        
		[BlockValue("Url")]
		public string ShortUrl { get; set; }

	    /// <summary>
		/// When user started editing
		/// </summary>
		[BlockValue("Created")]
		public DateTime Created{get; private set;}
		
		/// <summary>
		/// When published. Can be changed by user
		/// </summary>
		[BlockValue("Posted")]
		public DateTime Posted{get; set;}
		
		public BlogPost(){
			Created = DateTime.Now;
            Posted = DateTime.Now;
			Id = Guid.NewGuid();
		}

	    public string BodyHtml
	    {
	        get { var md = new MarkdownDeep.Markdown {ExtraMode = true};
	            return md.Transform(BodyText);
	        }
	    }
	    
	    public TemplateBlock GetTemplateBlock(){
	    	var block = new TemplateBlock("Post");
	    	block.AddPageType(BlogPageType.Any);
	    	block.AddValue("Title", Title);
	    	block.AddValue("ShortUrl", ShortUrl);
	    	string html = BodyHtml;
	    	block.AddValue("Body", html);
	    	block.AddValue("BodyShort", html);
	    	block.AddValue("Posted", Posted.ToString("dd.MM.yy HH:mm"));
	    	
	    	return block;
	    }
	    
	    #region Equals and GetHashCode implementation
	    public override bool Equals(object obj)
		{
			BlogPost other = obj as BlogPost;
			if (other == null)
				return false;
			return this.Id == other.Id && this.Title == other.Title && this.BodyText == other.BodyText && this.ShortUrl == other.ShortUrl && this.Created == other.Created && this.Posted == other.Posted;
		}
	    
		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * Id.GetHashCode();
				if (Title != null)
					hashCode += 1000000009 * Title.GetHashCode();
				if (BodyText != null)
					hashCode += 1000000021 * BodyText.GetHashCode();
				if (ShortUrl != null)
					hashCode += 1000000033 * ShortUrl.GetHashCode();
				hashCode += 1000000087 * Created.GetHashCode();
				hashCode += 1000000093 * Posted.GetHashCode();
			}
			return hashCode;
		}
	    
		public static bool operator ==(BlogPost lhs, BlogPost rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}
	    
		public static bool operator !=(BlogPost lhs, BlogPost rhs)
		{
			return !(lhs == rhs);
		}
	    #endregion

	}
}
