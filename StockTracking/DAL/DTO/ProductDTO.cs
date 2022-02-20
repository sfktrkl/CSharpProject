using System.Collections.Generic;

namespace StockTracking.DAL.DTO
{
    public class ProductDTO
    {
        public List<ProductDetailDTO> Products { get; set; }
        public List<CategoryDetailDTO> Categories { get; set; }
    }
}
