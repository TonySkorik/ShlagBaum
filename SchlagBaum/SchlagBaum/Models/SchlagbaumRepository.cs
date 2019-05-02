using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchlagBaum.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace SchlagBaum.Models {
	public class SchlagbaumRepository {
		private SQLiteConnection _db;

		public SchlagbaumRepository(string filename) {
			string databasePath = DependencyService.Get<ISQlite>().GetDatabasePath(filename);
			_db = new SQLiteConnection(databasePath);
			_db.CreateTable<Baum>();
		}

		public IEnumerable<Baum> GetAllBaums() {
			return (
				from b in _db.Table<Baum>()
				select b
			).ToList();
		}

		public Baum GetBaumById(int baumId) {
			return _db.Get<Baum>(b=>b.Id == baumId);
		}

		public Baum GetBaumByCardinal(int baumCardinal) {
			return _db.Get<Baum>(b=>b.CardinalNumber == baumCardinal);
		}

		public int DeleteBaum(int baumId) {
			return _db.Delete<Baum>(baumId);
		}

		public int SaveBaum(Baum b) {
			if (b.Id != 0) {
				return _db.Update(b);
			} else {
				return _db.Insert(b);
			}
		}

	}
}
