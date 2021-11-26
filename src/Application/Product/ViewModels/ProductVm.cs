using System.Collections.Generic;
using Domain.Entities.Product;

namespace Application.Product.ViewModels
{
    public class ProductVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public IList<AdditionalInformation> AdditionalInformations { get; set; }
    }
}