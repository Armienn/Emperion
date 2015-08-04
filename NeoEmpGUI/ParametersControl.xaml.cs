using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeoEmpGUI {
	/// <summary>
	/// Interaction logic for ParametersControl.xaml
	/// </summary>
	public partial class ParametersControl : UserControl {
		MainWindow main;

		public ParametersControl(MainWindow mainwindow) {
			InitializeComponent();
			main = mainwindow;
		}

		private void TextBoxEnsureIntegers(object sender, TextChangedEventArgs e) {
			TextBox box = sender as TextBox;
			if (box != null) {
				string tmp = box.Text;
				foreach (char c in box.Text.ToCharArray()) {
					if (!System.Text.RegularExpressions.Regex.IsMatch(c.ToString(), "^[0-9]*$")) {
						tmp = tmp.Replace(c.ToString(), "");
					}
				}
				box.Text = tmp;
			}
		}
	}
}
