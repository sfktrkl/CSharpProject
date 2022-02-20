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
            throw new NotImplementedException();
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
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

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO
            {
                Sales = sales.Select(),
                Products = products.Select(),
                Customers = customers.Select(),
                Categories = categories.Select()
            };
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
