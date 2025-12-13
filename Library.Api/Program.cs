using Library.Domain.Interfaces;
using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. DbContext ---
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// --- 2. Repository DI ---
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// --- 3. Service DI ---
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

// Eventing
builder.Services.AddSingleton<IEventPublisher, InMemoryEventPublisher>();
builder.Services.AddScoped<Library.Application.Handlers.ReservationCreatedHandler>();

// --- 4. Controllers & Swagger ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- 5. Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    SeedData.Initialize(db);

    // demo: wire handler to events in-memory (subscribe)
    var publisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>() as Library.Application.Services.InMemoryEventPublisher;
    var handler = scope.ServiceProvider.GetRequiredService<Library.Application.Handlers.ReservationCreatedHandler>();

    // simple polling to demonstrate reaction (not production pattern)
    _ = Task.Run(async () =>
    {
        while (true)
        {
            var events = Library.Application.Services.InMemoryEventPublisher.GetPublishedEvents();
            foreach (var e in events)
            {
                if (e is Library.Domain.Events.ReservationCreatedEvent r)
                {
                    await handler.HandleAsync(r);
                }
            }

            await Task.Delay(2000);
        }
    });
}

app.Run();
