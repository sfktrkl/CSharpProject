using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Linq;
using System;

namespace StockTracking.DAL.DAO
{
    public class CategoryDAO : StockContext, IDAO<CATEGORY, CategoryDetailDTO>
    {
        public bool Delete(CATEGORY entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CATEGORY entity)
        {
            try
            {
                db.CATEGORies.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CategoryDetailDTO> Select()
        {
            try
            {
                return (from c in db.CATEGORies
                        select new CategoryDetailDTO
                        {
                            ID = c.ID,
                            CategoryName = c.CategoryName
                        }).OrderBy(x => x.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(CATEGORY entity)
        {
            throw new NotImplementedException();
        }
    }
}
