using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SchlagBaum.Models {
	[Table("Schlagbaums")]
	public class Baum {
		[PrimaryKey,Unique,AutoIncrement,Column("_id")]
		public int Id { set; get; }
		public int CardinalNumber { set; get; }
		public string TelephoneNumber { set; get; }
		public string Description { set; get; }
	}
}
