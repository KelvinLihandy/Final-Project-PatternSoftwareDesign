using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
	public class MsCategoryRepository
	{
		private static DatabaseJewel db = Singleton.GetDatabase();

		public static List<MsCategory> GetCategories()
		{
			return (from category in db.MsCategories select category).ToList();
		}
	}
}