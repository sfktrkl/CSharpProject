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
        private readonly SalesDAO sales = new SalesDAO();

        public bool Delete(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT
            {
                ID = entity.ProductID
            };
            SALE sale = new SALE
            {
                ProductID = entity.ProductID
            };
            return products.Delete(product) && sales.Delete(sale);
        }

        public bool GetBack(ProductDetailDTO entity)
        {
            return products.GetBack(entity.ProductID);
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

        public ProductDTO Select(bool isDeleted = false)
        {
            return new ProductDTO
            {
                Categories = categories.Select(isDeleted),
                Products = products.Select(isDeleted)
            };
        }

        public bool Update(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT
            {
                ID = entity.ProductID,
                Price = entity.Price,
                ProductName = entity.ProductName,
                StockAmount = entity.StockAmount,
                CategoryID = entity.CategoryID
            };
            return products.Update(product);
        }
    }
}
