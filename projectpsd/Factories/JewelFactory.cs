using System;
using projectpsd.Model;

namespace projectpsd.Factories
{
    public static class JewelFactory
    {
        public static MsJewel CreateNewJewel(string jewelName, int categoryId, int brandId, int price, int releaseYear)
        {
            return new MsJewel
            {
                JewelName = jewelName,
                CategoryID = categoryId,
                BrandID = brandId,
                JewelPrice = price,
                JewelReleaseYear = releaseYear
            };
        }
        public static MsJewel UpdateJewel(MsJewel existingJewel, string jewelName, int categoryId, int brandId, int price, int releaseYear)
        {
            if (existingJewel == null) throw new ArgumentNullException(nameof(existingJewel));

            existingJewel.JewelName = jewelName;
            existingJewel.CategoryID = categoryId;
            existingJewel.BrandID = brandId;
            existingJewel.JewelPrice = price;
            existingJewel.JewelReleaseYear = releaseYear;
            
            return existingJewel;
        }
    }
}