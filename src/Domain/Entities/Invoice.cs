using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Invoice : AuditEntity
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal AmountPaid { get; set; }
        public DiscountType DiscountType { get; set; }
        public TaxType TaxType { get; set; }
        public IList<InvoiceItem> InvoiceItems { get; set; }
    }
}