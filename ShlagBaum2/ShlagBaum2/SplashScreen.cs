using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace ShlagBaum2
{
	[Activity(
		Label = "@string/app_name",
		Theme = "@style/AppTheme.NoActionBar",
		MainLauncher = true,
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen
		: MvxSplashScreenAppCompatActivity<MvxAppCompatSetup<ShlagBaum.AppCore.App>, ShlagBaum.AppCore.App>
	{
		public SplashScreen()
			: base(Resource.Layout.SplashScreen)
		{ }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
		}
	}
}