using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        DbSet<Domain.Entities.ProductCategory> ProductCategories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<AdditionalInformation> AdditionalInformations { get; set; }
        DbSet<Domain.Entities.Product.Product> Products { get; set; }
    }
}