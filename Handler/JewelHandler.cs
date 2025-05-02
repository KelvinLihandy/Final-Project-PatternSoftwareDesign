using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Repository;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Handler
{
    public class JewelHandler
    {
        private MsJewelRepository jewelRepo;

        public JewelHandler()
        {
            jewelRepo = new MsJewelRepository();
        }

        public List<MsJewel> GetAllJewels()
        {
            return jewelRepo.GetAllJewels();
        }

        public MsJewel GetJewelById(int jewelId)
        {
            return jewelRepo.GetJewelById(jewelId);
        }

        public bool InsertJewel(int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            // Validate data before insertion
            if (string.IsNullOrEmpty(jewelName))
                return false;
            if (jewelPrice <= 0)
                return false;
            if (jewelReleaseYear <= 0)
                return false;

            // Insert jewel using repository
            return jewelRepo.InsertJewel(brandId, categoryId, jewelName, jewelPrice, jewelReleaseYear);
        }

        public bool UpdateJewel(int jewelId, int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            // Validate data before update
            if (string.IsNullOrEmpty(jewelName))
                return false;
            if (jewelPrice <= 0)
                return false;
            if (jewelReleaseYear <= 0)
                return false;

            // Update jewel using repository
            return jewelRepo.UpdateJewel(jewelId, brandId, categoryId, jewelName, jewelPrice, jewelReleaseYear);
        }

        public bool DeleteJewel(int jewelId)
        {
            return jewelRepo.DeleteJewel(jewelId);
        }
    }
}