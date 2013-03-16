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
		const string ASSETS_PATH = "{0}/{1}/assets/";
		
		public string LoadedTemplate{get;private set;}
		public string Name{get;private set;}
		
		public Template(string name)
		{
			Name = name;
			LoadedTemplate = File.ReadAllText(String.Format(TEMPLATE_PATH, TEMPLATE_FOLDER, name));			
		}
		
		public string AssetsPath
		{
			get {return String.Format(ASSETS_PATH, TEMPLATE_FOLDER, Name);}
		}
		
		public static IEnumerable<string> GetThemesList()
		{
			return Directory.EnumerateDirectories(TEMPLATE_FOLDER);
		}
	}
}
