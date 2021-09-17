using System;
using System.Collections.Generic;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using InvoiceManagementApp.Domain.Enums;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Commands
{
    
    public class CreateInvoiceCommand : IRequest<int>
    {
        public CreateInvoiceCommand()
        {
            InvoiceItems = new List<InvoiceItemVm>();
        }

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

        // ReSharper disable once MemberCanBePrivate.Global
        public IList<InvoiceItemVm> InvoiceItems { get; set; }
    }
}