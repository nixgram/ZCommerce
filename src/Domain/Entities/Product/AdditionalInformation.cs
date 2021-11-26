using Domain.Common;

namespace Domain.Entities.Product
{
    public class AdditionalInformation : AuditEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}