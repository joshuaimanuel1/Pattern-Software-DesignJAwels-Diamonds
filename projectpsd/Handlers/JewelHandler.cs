using System;
using System.Collections.Generic;
using projectpsd.Model;
using projectpsd.Repositories;
using projectpsd.Factories;
using projectpsd.Utils;

namespace projectpsd.Handlers
{
    public class JewelHandler
    {
        private JewelRepository jewelRepository;

        public JewelHandler()
        {
            jewelRepository = new JewelRepository();
        }

        
        public List<MsJewel> GetAllJewels()
        {
            return jewelRepository.GetAllJewelsWithDetails();
        }

        
        public MsJewel GetJewelDetail(int jewelId)
        {
            return jewelRepository.GetJewelDetailsById(jewelId);
        }

        
        public List<MsCategory> GetAllCategories()
        {
            return jewelRepository.GetAllCategories();
        }

        
        public List<MsBrand> GetAllBrands()
        {
            return jewelRepository.GetAllBrands();
        }

        
        public string AddNewJewel(string jewelName, int categoryId, int brandId, int price, int releaseYear)
        {
            
            if (!ValidationHelper.IsLengthBetween(jewelName, 3, 25))
            {
                return "Jewel Name must be between 3 to 25 characters (inclusive).";
            }
            if (price <= 25) 
            {
                return "Price must be a number and more than $25.";
            }
            if (!ValidationHelper.IsJewelReleaseYearValid(releaseYear)) 
            {
                return "Release Year must be a number and less than 2025.";
            }
            
            if (jewelRepository.GetById(categoryId) == null && categoryId != 0) 
            {
                
            }
            if (jewelRepository.GetById(brandId) == null && brandId != 0) 
            {
                
            }


            
            MsJewel newJewel = JewelFactory.CreateNewJewel(jewelName, categoryId, brandId, price, releaseYear);

            
            jewelRepository.Add(newJewel);

            return "Jewel added successfully.";
        }

        
        public string UpdateExistingJewel(int jewelId, string jewelName, int categoryId, int brandId, int price, int releaseYear)
        {
            MsJewel existingJewel = jewelRepository.GetById(jewelId);
            if (existingJewel == null)
            {
                return "Jewel not found.";
            }

            
            if (!ValidationHelper.IsLengthBetween(jewelName, 3, 25))
            {
                return "Jewel Name must be between 3 to 25 characters (inclusive).";
            }
            if (price <= 25)
            {
                return "Price must be a number and more than $25.";
            }
            if (!ValidationHelper.IsJewelReleaseYearValid(releaseYear))
            {
                return "Release Year must be a number and less than 2025.";
            }
            

            
            MsJewel updatedJewel = JewelFactory.UpdateJewel(existingJewel, jewelName, categoryId, brandId, price, releaseYear);

            
            jewelRepository.Update(updatedJewel);

            return "Jewel updated successfully.";
        }

        
        public string DeleteJewel(int jewelId)
        {
            MsJewel jewelToDelete = jewelRepository.GetById(jewelId);
            if (jewelToDelete == null)
            {
                return "Jewel not found.";
            }

            jewelRepository.Delete(jewelId); 
            return "Jewel deleted successfully.";
        }
    }
}