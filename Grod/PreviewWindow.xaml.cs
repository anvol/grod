/*
 * Created by SharpDevelop.
 * User: Andrey
 * Date: 11.03.2013
 * Time: 23:06
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
	/// Interaction logic for PreviewWindow.xaml
	/// </summary>
	public partial class PreviewWindow : Window
	{
		public PreviewWindow(string page)
		{
			InitializeComponent();
			
			wbMain.NavigateToString(page);
		}
		
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				e.Handled = true;
				this.Close();
				return;
			}
			base.OnKeyUp(e);			
		}
	}
}