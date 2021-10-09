using AutoMapper;
using ZCommerce.Application.Invoices.Commands;
using ZCommerce.Application.Invoices.ViewModels;
using ZCommerce.Application.ProductCategory.Commands;
using ZCommerce.Application.ProductCategory.ViewModel;
using ZCommerce.Domain.Entities;

namespace ZCommerce.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Invoice, InvoiceVm>();
            CreateMap<InvoiceItem, InvoiceItemVm>();
            CreateMap<InvoiceVm, Invoice>();
            CreateMap<InvoiceItemVm, InvoiceItem>();
            CreateMap<CreateInvoiceCommand, Invoice>();

            CreateMap<CreateProductCategoryCommand, Domain.Entities.ProductCategory>();
            CreateMap<Domain.Entities.ProductCategory, ProductCategoryVm>();
            CreateMap<UpdateProductCategoryCommand, Domain.Entities.ProductCategory>();
        }
    }
}