/*
 * User: Andrey
 * Date: 16.03.2013
 * Time: 15:54
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Grod
{
	[TestFixture]
	public class TestTemplateHelper
	{
		[Test]
		public void TestRemoveUnusedBlocks()
		{
			string input = "{test}Hello world!{/test}";
			string output;
			string outputSample = "{test}Hello world!{/test}";
			
			List<PropertieBag> blocks = new List<PropertieBag>();
			blocks.Add(new PropertieBag("test").AddPageType(BlogPageType.Page));
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Page);
			
			Assert.AreEqual(outputSample, output, "TemplateHelper.RemoveUnusedBlocks is broken");
			
			input = "{test2}Hello world!{/test2}";
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Page);
			
			Assert.AreEqual(input, output, "TemplateHelper.RemoveUnusedBlocks is broken");
			
			input = "{test}Hello world!{/test}";
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Blogroll);
			
			Assert.AreEqual("", output, "TemplateHelper.RemoveUnusedBlocks is broken");
		}
	}
}
