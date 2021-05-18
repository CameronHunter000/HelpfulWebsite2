using System.Threading;
using System.Threading.Tasks;
using HelpfulWebsite_2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpfulWebsite_2.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
