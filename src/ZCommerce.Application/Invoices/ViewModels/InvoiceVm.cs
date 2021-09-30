using System;
using System.Collections.Generic;
using ZCommerce.Domain.Enums;

namespace ZCommerce.Application.Invoices.ViewModels
{
    public class InvoiceVm
    {
        public InvoiceVm()
        {
            InvoiceItems = new List<InvoiceItemVm>();
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
        public IList<InvoiceItemVm> InvoiceItems { get;  set; }
        public DateTime Created { get; set; }
    }
}