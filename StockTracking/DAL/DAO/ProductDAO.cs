using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System;
using System.Linq;

namespace StockTracking.DAL.DAO
{
    class ProductDAO : StockContext, IDAO<PRODUCT, ProductDetailDTO>
    {
        public bool Delete(PRODUCT entity)
        {
            try
            {
                List<PRODUCT> products = new List<PRODUCT>();
                if (entity.ID != 0)
                    products.Add(db.PRODUCTs.First(x => x.ID == entity.ID));
                else if (entity.CategoryID != 0)
                    products.AddRange(db.PRODUCTs.Where(x => x.CategoryID == entity.CategoryID).ToList());

                foreach (var item in products)
                {
                    item.isDeleted = true;
                    item.DeletedDate = DateTime.Today;
                    List<SALE> sales = db.SALES.Where(x => x.ProductID == item.ID).ToList();
                    foreach (var item2 in sales)
                    {
                        item2.isDeleted = true;
                        item2.DeletedDate = DateTime.Today;
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PRODUCT entity)
        {
            try
            {
                db.PRODUCTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                return (from p in db.PRODUCTs.Where(x => x.isDeleted == false)
                        join c in db.CATEGORies on p.CategoryID equals c.ID
                        select new ProductDetailDTO
                        {
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            StockAmount = p.StockAmount,
                            Price = p.Price,
                            ProductID = p.ID,
                            CategoryID = c.ID
                        }).OrderBy(x => x.ProductName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(PRODUCT entity)
        {
            try
            {
                PRODUCT product = db.PRODUCTs.First(x => x.ID == entity.ID);
                if (entity.CategoryID == 0)
                    product.StockAmount = entity.StockAmount;
                else
                {
                    product.ProductName = entity.ProductName;
                    product.Price = entity.Price;
                    product.CategoryID = entity.CategoryID;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
