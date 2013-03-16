/*
 * User: Andrey
 * Date: 16.03.2013
 * Time: 15:08
 */

namespace Grod
{
	/// <summary>
	/// Types of pages on blog.
	/// </summary>
	public enum BlogPageType
	{
		Blogroll,
		Post,
		Page,
		Archive,
		
		/// <summary>
		/// Indicates that object should be placed on any page
		/// </summary>
		Any
	}
}