using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // Pastikan referensi ini ada

namespace FinalProjectPSD.Repository
{
    public class MsJewelRepository
    {
        private static DatabaseJewel db = Singleton.GetDatabase();

        public static bool PostNewJewel(MsJewel newJewel)
        {
            db.MsJewels.Add(newJewel);
            return db.SaveChanges() > 0;
        }


        public static List<MsJewel> GetAllJewels()
        {
  
            return db.MsJewels
                .Include(j => j.MsBrand)
                .Include(j => j.MsCategory)
                .ToList();
        }


        public static MsJewel GetJewelById(int jewelId)
        {
            return db.MsJewels
                .Include(j => j.MsBrand)
                .Include(j => j.MsCategory)
                .FirstOrDefault(j => j.JewelID == jewelId);
        }

    }
}