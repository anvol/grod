/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 11.03.2013
 * Time: 22:47
 */
using System;

namespace Grod
{
	/// <summary>
	/// Provides methods to generate html output.
	/// </summary>
	public class HtmlHelper
	{
		// Used to generate Read More link
		const string LINK_MORE = @"<a href=""{0}"" class=""btn-read-more"" type=""button"">{1}</button>";
		
		/// <summary>
		/// Generate link to page with full blog post
		/// </summary>
		/// <param name="linkToFullPage">Link to page</param>
		/// <param name="linkText">Text to display.</param>
		/// <returns>Html output</returns>
		public static string LinkReadMore(string linkToFullPage, string linkText = "Read More"){
			return String.Format(LINK_MORE, linkToFullPage, linkText);
		}
	}
}
