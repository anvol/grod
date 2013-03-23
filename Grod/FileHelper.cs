/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 16.03.2013
 * Time: 22:00
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace Grod
{
	public class FileHelper
	{
		const string PUBLISH_DIR = "Publish/";
		
		public static void CreateFiles(IEnumerable<HtmlPage> pages)
		{
			foreach (var page in pages) {
				string path = PUBLISH_DIR + page.RelativePath;
				Directory.CreateDirectory(path);
				File.WriteAllText(path + "/index.html", page.Text);				
			}
		}
		
		public static void CopyAssets(string source)
		{
			DirectoryCopy(source, PUBLISH_DIR + "assets/", true);
		}
		
		public static void ClearPublishDir()
		{
			if (Directory.Exists(PUBLISH_DIR)) Directory.Delete(PUBLISH_DIR, true);
			Directory.CreateDirectory(PUBLISH_DIR);
		}
		
		public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
	    {
	        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
	        DirectoryInfo[] dirs = dir.GetDirectories();
	
	        if (!dir.Exists)
	        {
	            throw new DirectoryNotFoundException(
	                "Source directory does not exist or could not be found: "
	                + sourceDirName);
	        }
	
	        if (!Directory.Exists(destDirName))
	        {
	            Directory.CreateDirectory(destDirName);
	        }
	
	        FileInfo[] files = dir.GetFiles();
	        foreach (FileInfo file in files)
	        {
	            string temppath = Path.Combine(destDirName, file.Name);
	            file.CopyTo(temppath, false);
	        }
	
	        if (copySubDirs)
	        {
	            foreach (DirectoryInfo subdir in dirs)
	            {
	                string temppath = Path.Combine(destDirName, subdir.Name);
	                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
	            }
	        }
	    }
	}
}
