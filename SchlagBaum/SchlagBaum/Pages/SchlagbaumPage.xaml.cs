using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SchlagBaum.Interfaces;
using SchlagBaum.Models;
using Xamarin.Forms;

namespace SchlagBaum.Pages {
	public partial class SchlagbaumPage : ContentPage {
		public SchlagbaumPage() {
			InitializeComponent();
		}

		private bool ValidateTelephoneNumber(string tel) {
			Regex re = new Regex(@"^\+[0-9]{10}[0-9]$");
			return re.Match(tel).Success;
		}


		private void ButtonSave_OnClicked(object sender, EventArgs e) {
			Baum b = (Baum) this.BindingContext;
			if (!string.IsNullOrEmpty(b.Description)) {
				if (!string.IsNullOrEmpty(b.TelephoneNumber)) {
					if (ValidateTelephoneNumber(b.TelephoneNumber)) {
						App.Database.SaveBaum(b);
						this.Navigation.PopAsync();
					} else {
						DisplayAlert("Telephone number", "Invalid telephone number\nexample: +79161232334", "OK");
					}
				} else {
					DisplayAlert("Telephone number", "Telephone number field is required", "OK");
				}
			} else {
				DisplayAlert("Description", "Description field is required", "OK");
			}
		}

		private void ButtonCancel_OnClicked(object sender, EventArgs e) {
			this.Navigation.PopAsync();
		}
		
		private async void ButtonDel_OnClicked(object sender, EventArgs e) {
			Baum b = (Baum) this.BindingContext;
			if (b.Id != 0) {
				var answer = await DisplayAlert("Delete entry", "Delete selected entry?", "Yes", "No");
				if(answer) {
					App.Database.DeleteBaum(b.Id);
					this.Navigation.PopAsync();
				}
			}
		}

		private async void ButtonOpen_OnClicked(object sender, EventArgs e) {
			Baum b = (Baum) this.BindingContext;
			if (b.Id != 0) {
				await DependencyService.Get<IPhone>()?.Call(b.TelephoneNumber);
			}
		}
	}
}
