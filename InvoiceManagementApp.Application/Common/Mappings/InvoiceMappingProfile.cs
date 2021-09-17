using AutoMapper;
using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using InvoiceManagementApp.Domain.Entities;

namespace InvoiceManagementApp.Application.Common.Mappings
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