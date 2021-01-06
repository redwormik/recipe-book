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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace Lecture15
{

	/// <summary>
	/// Interakční logika pro MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<Model.Ingredient> ingredients = new ObservableCollection<Model.Ingredient>();

		private IngredientWindow ingredientWindow;

		private SqlConnection connection;


		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this.ingredients;
			this.connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CookBook.mdf;Integrated Security=True;Connect Timeout=30");
			connection.Open();

			SqlCommand query = connection.CreateCommand();
			query.CommandText = "SELECT * FROM Ingredient ORDER BY Name";
			SqlDataReader result = query.ExecuteReader();
			while (result.NextResult()) {
				int id = result.GetInt32(0);
				string name = result.GetString(1);
				this.ingredients.Add(new Model.Ingredient(id, name));
			}
		}

		private void IngredientsButton_Click(object sender, RoutedEventArgs e)
		{
			if (ingredientWindow == null) {
				ingredientWindow = new IngredientWindow(ingredients);
				ingredientWindow.Closed += delegate {
					ingredientWindow = null;
				};
			}

			ingredientWindow.Show();
			ingredientWindow.Focus();
		}
	}
}
