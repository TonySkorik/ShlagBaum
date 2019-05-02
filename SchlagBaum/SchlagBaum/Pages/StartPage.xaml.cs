using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchlagBaum.Interfaces;
using SchlagBaum.Models;
using Xamarin.Forms;

namespace SchlagBaum.Pages {
	public partial class StartPage : ContentPage {
		public StartPage() {
			InitializeComponent();
		}

		protected override void OnAppearing() {
			SchlagBaumView.ItemsSource = App.Database.GetAllBaums().OrderByDescending(b=>b.CardinalNumber);
			base.OnAppearing();
		}

		private async void ButtonViewMap_OnClicked(object sender, EventArgs e) {
			string mapPath = DependencyService.Get<IImage>().GetImagePath("map.png");

			await Navigation.PushAsync(new MapPage() {
				BindingContext = DependencyService.Get<IImage>().GetImagePath("map.png")
			});
		}

		private async void SchlagBaumView_OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
			Baum b = (Baum) e.SelectedItem;
			SchlagbaumPage page = new SchlagbaumPage{
				BindingContext = b
			};
			await Navigation.PushAsync(page);
		}

		private async void ButtonAddSchlagbaum_OnClicked(object sender, EventArgs e) {
			Baum b = new Baum();
			SchlagbaumPage page = new SchlagbaumPage {
				BindingContext = b
			};
			await Navigation.PushAsync(page);
		}
	}
}
