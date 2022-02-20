using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;
using System;

namespace StockTracking.BLL
{
    public class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        private readonly CategoryDAO categories = new CategoryDAO();
        private readonly ProductDAO products = new ProductDAO();

        public bool Delete(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT
            {
                ProductName = entity.ProductName,
                CategoryID = entity.CategoryID,
                Price = entity.Price
            };
            return products.Insert(product);
        }

        public ProductDTO Select()
        {
            return new ProductDTO
            {
                Categories = categories.Select(),
                Products = products.Select()
            };
        }

        public bool Update(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
