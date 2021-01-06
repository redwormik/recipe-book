using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Lecture15.Model
{
	public class Ingredient: INotifyPropertyChanged
	{
		private int? _Id;
		public int? Id
		{
			get {
				return _Id;
			}
		}

		private string _Name;
		public string Name
		{
			get {
				return _Name;
			}

			set {
				_Name = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;


		public Ingredient(int? Id, string Name)
		{
			_Id = Id;
			_Name = Name;
		}


		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
