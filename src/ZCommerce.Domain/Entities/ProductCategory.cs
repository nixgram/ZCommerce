using ZCommerce.Domain.Common;

namespace ZCommerce.Domain.Entities
{
    public class ProductCategory : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
    }
}