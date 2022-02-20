using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System;
using System.Linq;

namespace StockTracking.DAL.DAO
{
    public class CustomerDAO : StockContext, IDAO<CUSTOMER, CustomerDetailDTO>
    {
        public bool Delete(CUSTOMER entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CUSTOMER entity)
        {
            try
            {
                db.CUSTOMERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select()
        {
            try
            {
                return (from c in db.CUSTOMERs
                        select new CustomerDetailDTO
                        {
                            ID = c.ID,
                            CustomerName = c.CustomerName
                        }).OrderBy(x => x.CustomerName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == entity.ID);
                customer.CustomerName = entity.CustomerName;
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
