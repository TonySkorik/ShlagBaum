﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SchlagBaum.Pages {
	public partial class MapPage : ContentPage {
		public MapPage() {
			InitializeComponent();
		}

		protected override void OnAppearing() {
			ImageMap.Source = (string)this.BindingContext;
			base.OnAppearing();
		}
	}
}