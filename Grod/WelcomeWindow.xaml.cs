/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 03/05/2013
 * Time: 21:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
			var editor = new EditorWindow();
			
			editor.Owner = this;
			editor.ShowActivated = true;
			editor.Show();
		}
	}
}