/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 16.03.2013
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Grod
{
	/// <summary>
	/// Description of BlockValueAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
	public class BlockValueAttribute : Attribute
	{
		public readonly string Name;
		
		public BlockValueAttribute(string name)
		{
			Name = name;
		}
	}
}
