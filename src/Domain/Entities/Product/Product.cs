using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities.Product
{
    public class Product : AuditEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public IList<AdditionalInformation> AdditionalInformations { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}