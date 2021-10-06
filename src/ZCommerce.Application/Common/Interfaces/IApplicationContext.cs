using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZCommerce.Domain.Entities;

namespace ZCommerce.Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}