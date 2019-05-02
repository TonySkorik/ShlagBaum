using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchlagBaum.Interfaces {
	public interface ISQlite {
		string GetDatabasePath(string filename);
	}
}
