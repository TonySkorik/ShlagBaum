using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchlagBaum.Interfaces {
	public interface IImage {
		string GetImagePath(string imageName);
	}
}
