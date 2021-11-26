using Application.Invoices.Commands;
using Application.Invoices.ViewModels;
using Application.Product.Commands;
using Application.Product.ViewModels;
using Application.ProductCategory.Commands;
using Application.ProductCategory.ViewModel;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Product;

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


            CreateMap<Domain.Entities.Product.Product, CreateProductCommand>().ReverseMap();
            CreateMap<CreateProductCommand, Domain.Entities.Product.Product>();
            CreateMap<ProductVm, CreateProductCommand>();
            CreateMap<Domain.Entities.Product.Product, ProductVm>();
            CreateMap<AdditionalInformation, AdditionalInformationVm>();
            CreateMap<AdditionalInformationVm, AdditionalInformation>();
        }
    }
}