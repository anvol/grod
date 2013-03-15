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
	    private string _page;
	    private string _list;
	    private string _post;

		const string TEMPLATE_FOLDER = "Themes";
		const string TEMPLATE_PATH = "{0}/{1}/template.html";
			
		public Template(string name)
		{
			_loadedTemplate = File.ReadAllText(String.Format(TEMPLATE_PATH, TEMPLATE_FOLDER, name));
		}

        private string PostListBlock()
        {
            throw NotImplementedException();
        }
		
		public static IEnumerable<string> GetThemesList()
		{
			return Directory.EnumerateDirectories(TEMPLATE_FOLDER);
		}
	}
}
