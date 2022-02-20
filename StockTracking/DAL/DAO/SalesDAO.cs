﻿using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Linq;
using System;

namespace StockTracking.DAL.DAO
{
    class SalesDAO : StockContext, IDAO<SALE, SalesDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SALE entity)
        {
            try
            {
                db.SALES.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesDetailDTO> Select()
        {
            try
            {
                return (from s in db.SALES.Where(x => x.isDeleted == false)
                        join p in db.PRODUCTs on s.ProductID equals p.ID
                        join c in db.CUSTOMERs on s.CustomerID equals c.ID
                        join category in db.CATEGORies on s.CategoryID equals category.ID
                        select new SalesDetailDTO
                        {
                            ProductName = p.ProductName,
                            CustomerName = c.CustomerName,
                            CategoryName = category.CategoryName,
                            ProductID = s.ProductID,
                            CustomerID = s.CustomerID,
                            SalesID = s.ID,
                            CategoryID = s.CategoryID,
                            Price = s.ProductSalePrice,
                            SalesAmount = s.ProductSaleAmount,
                            SalesDate = s.SalesDate
                        }).OrderBy(x => x.SalesDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SALE entity)
        {
            throw new NotImplementedException();
        }
    }
}