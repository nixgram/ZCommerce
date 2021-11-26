using Application.Invoices.Commands;
using Application.Invoices.ViewModels;
using Application.Product.Commands;
using Application.Product.ViewModels;
using Application.ProductCategory.Commands;
using Application.ProductCategory.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
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


            CreateMap<Domain.Entities.Product.Product, CreateProductCommand>();
            CreateMap<CreateProductCommand, Domain.Entities.Product.Product>();
            CreateMap<CreateProductCommand, ProductVm>();
            CreateMap<ProductVm, CreateProductCommand>();
        }
    }
}