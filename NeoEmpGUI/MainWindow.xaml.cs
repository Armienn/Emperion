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
using NeaKit.Geometry2D.Hex;
using NeoEmperion.World;

namespace NeoEmpGUI {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public World world;

		InfoControl infoControl;
		ParametersControl parametersControl;

		public MainWindow() {
			InitializeComponent();
			infoControl = new InfoControl(this);
			parametersControl = new ParametersControl(this);
			MainContent.Children.Add(infoControl);
		}

		private void ViewInfo_Click(object sender, RoutedEventArgs e) {
			MainContent.Children.Clear();
			MainContent.Children.Add(infoControl);
		}

		private void ViewParameters_Click(object sender, RoutedEventArgs e) {
			MainContent.Children.Clear();
			MainContent.Children.Add(parametersControl);
		}

		public void Generate(NeoEmperion.World.Parameters parameters) {
			//TODO: implement this
		}
	}
}
