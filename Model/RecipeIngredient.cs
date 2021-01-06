using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Lecture15.Model
{
	public class RecipeIngredient
	{
		public Recipe Recipe
		{
			get;
		}

		private Ingredient _Ingredient;
		public Ingredient Ingredient
		{
			get {
				return _Ingredient;
			}

			set {
				_Ingredient = value;
				OnPropertyChanged();
			}
		}

		private int _Amount;
		public int Amount
		{
			get {
				return _Amount;
			}

			set {
				_Amount = value;
				OnPropertyChanged();
			}
		}

		private string _Unit;
		public string Unit
		{
			get {
				return _Unit;
			}

			set {
				_Unit = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;


		public RecipeIngredient(Recipe recipe, Ingredient ingredient, int amount, string unit)
		{
			this.Recipe = recipe;
			this._Ingredient = ingredient;
			this._Amount = amount;
			this._Unit = unit;
		}


		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
