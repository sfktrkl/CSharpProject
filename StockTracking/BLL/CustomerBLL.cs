﻿using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;
using System;

namespace StockTracking.BLL
{
    public class CustomerBLL : IBLL<CustomerDetailDTO, CustomerDTO>
    {
        private readonly CustomerDAO customers = new CustomerDAO();

        public bool Delete(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CustomerDetailDTO entity)
        {
            CUSTOMER customer = new CUSTOMER
            {
                CustomerName = entity.CustomerName
            };
            return customers.Insert(customer);
        }

        public CustomerDTO Select()
        {
            return new CustomerDTO
            {
                Customers = customers.Select()
            };
        }

        public bool Update(CustomerDetailDTO entity)
        {
            CUSTOMER customer = new CUSTOMER
            {
                ID = entity.ID,
                CustomerName = entity.CustomerName
            };
            return customers.Update(customer);
        }
    }
}
