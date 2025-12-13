using Library.Domain.Events;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(IDomainEvent domainEvent);
    }
}
