using Library.Application.Interfaces;
using Library.Domain.Events;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System;

namespace Library.Application.Services
{
    // Very small in-memory publisher for demo/testing purposes
    public class InMemoryEventPublisher : IEventPublisher
    {
        private static readonly ConcurrentBag<IDomainEvent> _events = new();

        public Task PublishAsync(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
            Console.WriteLine($"Event published: {domainEvent.GetType().Name}");
            return Task.CompletedTask;
        }

        // helper for tests/debug
        public static IDomainEvent[] GetPublishedEvents() => _events.ToArray();
    }
}
