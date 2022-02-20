using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;
using System;

namespace StockTracking.BLL
{
    class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        readonly SalesDAO sales = new SalesDAO();
        private readonly ProductDAO products = new ProductDAO();
        private readonly CategoryDAO categories = new CategoryDAO();
        private readonly CustomerDAO customers = new CustomerDAO();

        public bool Delete(SalesDetailDTO entity)
        {
            SALE sale = new SALE
            {
                ID = entity.SalesID
            };
            PRODUCT product = new PRODUCT
            {
                ID = entity.ProductID,
                StockAmount = entity.StockAmount + entity.SalesAmount
            };
            return sales.Delete(sale) && products.Update(product);
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            PRODUCT product = new PRODUCT
            {
                ID = entity.ProductID,
                StockAmount = entity.StockAmount - entity.SalesAmount
            };
            return  sales.GetBack(entity.SalesID) && products.Update(product);
        }

        public bool Insert(SalesDetailDTO entity)
        {
            SALE sale = new SALE
            {
                CategoryID = entity.CategoryID,
                ProductID = entity.ProductID,
                CustomerID = entity.CustomerID,
                ProductSalePrice = entity.Price,
                ProductSaleAmount = entity.SalesAmount,
                SalesDate = entity.SalesDate
            };
            PRODUCT product = new PRODUCT
            {
                ID = entity.ProductID,
                StockAmount = entity.StockAmount - entity.SalesAmount
            };
            return (sales.Insert(sale) && products.Update(product));
        }

        public SalesDTO Select(bool isDeleted = false)
        {
            SalesDTO dto = new SalesDTO
            {
                Sales = sales.Select(isDeleted),
                Products = products.Select(isDeleted),
                Customers = customers.Select(isDeleted),
                Categories = categories.Select(isDeleted)
            };
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            SALE sale = new SALE
            {
                ID = entity.SalesID,
                ProductSaleAmount = entity.SalesAmount
            };
            PRODUCT product = new PRODUCT
            {
                ID = entity.ProductID,
                StockAmount = entity.StockAmount
            };
            return (sales.Update(sale) &&  products.Update(product));
        }
    }
}
