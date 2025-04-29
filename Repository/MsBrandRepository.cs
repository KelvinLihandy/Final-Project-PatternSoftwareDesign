using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
	public class MsBrandRepository
	{
		private static DatabaseJewel db = Singleton.GetDatabase();

		public static List<MsBrand> GetBrands()
		{
			return (from brand in db.MsBrands select brand).ToList();
		}
	}
}