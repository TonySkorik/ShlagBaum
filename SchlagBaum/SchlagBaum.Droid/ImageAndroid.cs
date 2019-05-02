using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SchlagBaum.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SchlagBaum.Droid.ImageAndroid))]
namespace SchlagBaum.Droid {
	public class ImageAndroid:IImage {
		public string GetImagePath(string imageName) {
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			string path = Path.Combine(documentsPath, imageName);

			if(!File.Exists(path)) {
				Stream dbAssetStream = Forms.Context.Assets.Open(imageName);
				FileStream dbFileStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
				byte[] buffer = new byte[1024];

				int b = buffer.Length;
				int length;

				while((length = dbAssetStream.Read(buffer, 0, b)) > 0) {
					dbFileStream.Write(buffer, 0, length);
				}

				dbFileStream.Flush();
				dbFileStream.Close();
				dbAssetStream.Close();
			}
			return path;
		}
	}
}