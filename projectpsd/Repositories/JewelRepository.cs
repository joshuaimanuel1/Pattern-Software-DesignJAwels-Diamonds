using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using projectpsd.Model;

namespace projectpsd.Repositories
{
    public class JewelRepository : BaseRepository<MsJewel>
    {
        public List<MsJewel> GetAllJewelsWithDetails()
        {
            return db.MsJewels.Include(j => j.MsCategory)
                               .Include(j => j.MsBrand)
                               .ToList();
        }

        public MsJewel GetJewelDetailsById(int jewelId)
        {
            return db.MsJewels.Include(j => j.MsCategory)
                               .Include(j => j.MsBrand)
                               .FirstOrDefault(j => j.JewelID == jewelId);
        }

        public List<MsCategory> GetAllCategories()
        {
            return db.MsCategories.ToList();
        }

        public List<MsBrand> GetAllBrands()
        {
            return db.MsBrands.ToList();
        }

        public List<MsJewel> GetJewelsByCategory(int categoryId)
        {
            return db.MsJewels.Where(j => j.CategoryID == categoryId).ToList();
        }
    }
}