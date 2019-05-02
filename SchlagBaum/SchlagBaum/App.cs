using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchlagBaum.Models;
using SchlagBaum.Pages;
using Xamarin.Forms;

namespace SchlagBaum {
	public class App : Application {
		public const string DATABASE_NAME = "schlagbaum.db";
		private static SchlagbaumRepository _database;
		public static SchlagbaumRepository Database => _database ?? (_database = new SchlagbaumRepository(DATABASE_NAME));

		public App() {
			MainPage = new NavigationPage(new StartPage());
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
