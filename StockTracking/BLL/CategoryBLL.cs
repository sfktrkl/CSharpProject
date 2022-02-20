using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;
using System;

namespace StockTracking.BLL
{
    public class CategoryBLL : IBLL<CategoryDetailDTO, CategoryDTO>
    {
        private readonly CategoryDAO categories = new CategoryDAO();
        private readonly ProductDAO products = new ProductDAO();

        public bool Delete(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY
            {
                ID = entity.ID
            };
            PRODUCT product = new PRODUCT
            {
                CategoryID = entity.ID
            };
            return categories.Delete(category) && products.Delete(product);
        }

        public bool GetBack(CategoryDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY()
            {
                CategoryName = entity.CategoryName
            };
            return categories.Insert(category);
        }

        public CategoryDTO Select()
        {
            return new CategoryDTO()
            {
                Categories = categories.Select()
            };
        }

        public bool Update(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY()
            {
                ID = entity.ID,
                CategoryName = entity.CategoryName
            };
            return categories.Update(category);
        }
    }
}
