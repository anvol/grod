﻿/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 03/05/2013
 * Time: 21:20
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

namespace Grod
{
	/// <summary>
	/// Interaction logic for EditorWindow.xaml
	/// </summary>
	public partial class EditorWindow : Window
	{
		BlogPost post;
		
		public EditorWindow(BlogPost post)
		{
			InitializeComponent();
			this.post = post;
			this.DataContext = post;
		}
		
		void ButtonPreview_Click(object sender, RoutedEventArgs e)
		{
			var pw = new PreviewWindow(post.BodyHtml){Owner = this};
			pw.ShowDialog();
		}
	}
}