using System.Collections.Generic;

namespace StockTracking.DAL.DTO
{
    public class SalesDTO
    {
        public List<SalesDetailDTO> Sales { get; set; }
        public List<CustomerDetailDTO> Customers { get; set; }
        public List<ProductDetailDTO> Products { get; set; }
        public List<CategoryDetailDTO> Categories { get; set; }
    }
}
