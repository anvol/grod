/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 17.03.2013
 * Time: 11:18
 */
using System;

namespace Grod
{
	/// <summary>
	/// Description of Blogroll.
	/// </summary>
	[BlockValue("Blogroll")]
	public class Blogroll
	{
		[BlockValue("RecentPosts")]
		public string RecentPosts {get;set;}
		
		[BlockValue("Pagination")]
		public string Pagination {get;set;}
	}
}
