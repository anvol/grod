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
		string _loadedTemplate;
		const string TEMPLATE_FOLDER = "Themes";
		const string TEMPLATE_PATH = "{0}/{1}/template.html";
			
		public Template(string name)
		{
			_loadedTemplate = File.ReadAllText(String.Format(TEMPLATE_PATH, TEMPLATE_FOLDER, name));
		}
		
		public static IEnumerable<string> GetThemesList()
		{
			return Directory.EnumerateDirectories(TEMPLATE_FOLDER);
		}
	}
}
