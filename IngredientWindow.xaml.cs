using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Lecture15
{
	/// <summary>
	/// Interakční logika pro IngredientWindow.xaml
	/// </summary>
	public partial class IngredientWindow : Window
	{
		private ObservableCollection<Model.Ingredient> data;


		public IngredientWindow(ObservableCollection<Model.Ingredient> data)
		{
			InitializeComponent();
			this.data = data;
			this.DataContext = this.data;
		}


		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			if (Name.Text == "") {
				return;
			}

			this.data.Add(new Model.Ingredient(null, Name.Text));
			Name.Text = "";
		}


		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			data.Remove((sender as Button).DataContext as Model.Ingredient);
		}
	}
}
