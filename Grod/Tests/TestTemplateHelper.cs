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
			
			List<TemplateBlock> blocks = new List<TemplateBlock>();
			blocks.Add(new TemplateBlock("test").AddPageType(BlogPageType.Page));
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Page);
			
			Assert.AreEqual(outputSample, output, "TemplateHelper.RemoveUnusedBlocks is broken");
			
			input = "{test2}Hello world!{/test2}";
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Page);
			
			Assert.AreEqual(input, output, "TemplateHelper.RemoveUnusedBlocks is broken");
			
			input = "{test}Hello world!{/test}";
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Blogroll);
			
			Assert.AreEqual("", output, "TemplateHelper.RemoveUnusedBlocks is broken");
		}
		
		[Test]
		public void TestReplaceTagWithData()
		{
			string template = "{Blog.Title}";
			string title = "Hello world";
			
			var block = new TemplateBlock("Blog");
			block.AddValue("Title", title);
			
			string output = TemplateHelper.ReplaceTagWithData(template, block);
			
			Assert.AreEqual(title, output);
			
			template = "{Blog.title}";
			output = TemplateHelper.ReplaceTagWithData(template, block);
			Assert.AreEqual(title, output);
		}
	}
}
