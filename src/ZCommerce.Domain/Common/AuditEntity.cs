using System;

namespace ZCommerce.Domain.Common
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public bool IsDisabled { get; set; }

        public string DisabledBy { get; set; }

        public DateTime DisabledOn { get; set; }

        public DateTime EnabledOn { get; set; }

        public string EnabledBy { get; set; }
    }
}