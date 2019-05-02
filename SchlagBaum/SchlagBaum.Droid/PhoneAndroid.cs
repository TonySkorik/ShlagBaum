using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SchlagBaum.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SchlagBaum.Droid.PhoneAndroid))]
namespace SchlagBaum.Droid {
	public class PhoneAndroid:IPhone {
		public Task Call(string phoneNumber) {
			PackageManager packageManager = Android.App.Application.Context.PackageManager;
			Android.Net.Uri telUri = Android.Net.Uri.Parse($"tel:{phoneNumber}");
			Intent callIntent = new Intent(Intent.ActionCall, telUri);

			callIntent.AddFlags(ActivityFlags.NewTask);
			// проверяем доступность
			bool result = null != callIntent.ResolveActivity(packageManager);

			if(!string.IsNullOrWhiteSpace(phoneNumber) && result == true) {
				Android.App.Application.Context.StartActivity(callIntent);
			}

			return Task.FromResult(true);
		}
	}
}