using System.Threading.Tasks;
using HelpfulWebsite_2.Domain.Common;

namespace HelpfulWebsite_2.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
