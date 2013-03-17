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
			
			input = "{test}Hello world!{/test}asd";
			output = TemplateHelper.RemoveUnusedBlocks(input, blocks, BlogPageType.Blogroll);
			
			Assert.AreEqual("asd", output, "TemplateHelper.RemoveUnusedBlocks is broken");
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
	
		[Test]
		public void TestBlockFromObject()
		{
			var blog = new Blog("test title", "hello world");
			var block = TemplateBlock.FromObject(blog);
			
			Assert.AreEqual("Blog", block.Name);
			Assert.AreEqual(blog.Title, block.GetValue("Title"));
			Assert.AreEqual(blog.Description, block.GetValue("Description"));
		}
		
		[Test]
		public void TestReplaceBlock()
		{
			string tpl = "Hey! {blogroll.loop}Test block{/blogroll.loop} test";
			string output = TemplateHelper.ReplaceBlockWithData(tpl, "blogroll.loop", "This is");
			
			Assert.AreEqual("Hey! This is test", output);
		}
		
		[Test]
		public void TestGetBlock()
		{
			string tpl = "Hey! {blogroll.loop}Test block{/blogroll.loop} test";
			string output = TemplateHelper.GetBlockText(tpl, "blogroll.loop");
			
			Assert.AreEqual("Test block", output);
		}
	}
}
