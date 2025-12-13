using Library.Domain.Events;
using System.Threading.Tasks;
using System;

namespace Library.Application.Handlers
{
    public class ReservationCreatedHandler
    {
        public Task HandleAsync(ReservationCreatedEvent ev)
        {
            // Example reaction: log / send notification / update other bounded context
            Console.WriteLine($"Handler reacting to ReservationCreated: ReservationId={ev.ReservationId}, BookId={ev.BookId}, UserId={ev.UserId}");
            return Task.CompletedTask;
        }
    }
}
