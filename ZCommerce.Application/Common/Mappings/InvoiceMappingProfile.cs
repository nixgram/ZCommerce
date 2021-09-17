using AutoMapper;
using ZCommerce.Application.Invoices.Commands;
using ZCommerce.Application.Invoices.ViewModels;
using ZCommerce.Domain.Entities;

namespace ZCommerce.Application.Common.Mappings
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceVm>();
            CreateMap<InvoiceItem, InvoiceItemVm>();
            CreateMap<InvoiceVm, Invoice>();
            CreateMap<InvoiceItemVm, InvoiceItem>();
            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}