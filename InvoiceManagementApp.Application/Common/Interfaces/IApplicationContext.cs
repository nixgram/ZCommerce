using System.Threading;
using System.Threading.Tasks;
using InvoiceManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}