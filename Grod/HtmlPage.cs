/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 16.03.2013
 * Time: 13:24
 */
using System;

namespace Grod
{
	/// <summary>
	/// Holds information about generated page.
	/// </summary>
	public class HtmlPage
	{
		/// <summary>
		/// Path where you should store the page
		/// </summary>
		/// <example>post-short-url</example>
		public string RelativePath { get; private set; }
		
		/// <summary>
		/// Html text of the page
		/// </summary>
		public string Text { get; private set; }
		
		public HtmlPage(string text, string path)
		{
			Text = text;
			RelativePath = path;
		}
	}
}
