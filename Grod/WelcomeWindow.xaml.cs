/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 03/05/2013
 * Time: 21:13
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;

namespace Grod
{
	/// <summary>
	/// Interaction logic for WelcomeWindow.xaml
	/// </summary>
	public partial class WelcomeWindow : Window
	{
		public WelcomeWindow()
		{
			InitializeComponent();
		}
		
		void btnNewPost_Click(object sender, RoutedEventArgs e)
		{
		    using (var db = new GrodDbContext())
		    {
		        for (int i = 0; i < 100; i++)
		        {
		            var post = new BlogPost() {Title = "Test " + i, BodyText = "Some body\r\n========\r\n\r\n - " + i};
		            db.Posts.Add(post);
		        }

		        db.SaveChanges();
		    }

			var editor = new EditorWindow(new BlogPost()) {Owner = this, ShowActivated = true};
		    editor.ShowDialog();
		}
	}
}