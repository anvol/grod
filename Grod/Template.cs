/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 11.03.2013
 * Time: 22:20
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Grod
{
	public class Template
	{
		const string TEMPLATE_FOLDER = "Themes";
		const string TEMPLATE_PATH = "{0}/{1}/template.html";
		
		public string LoadedTemplate{get;private set;}
			
		public Template(string name)
		{
			LoadedTemplate = File.ReadAllText(String.Format(TEMPLATE_PATH, TEMPLATE_FOLDER, name));
		}
		
		public static IEnumerable<string> GetThemesList()
		{
			return Directory.EnumerateDirectories(TEMPLATE_FOLDER);
		}
	}
}
