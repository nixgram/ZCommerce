using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        DbSet<Domain.Entities.ProductCategory> ProductCategories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}