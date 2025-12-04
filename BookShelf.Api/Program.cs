using BookShelf.Application.Interfaces;
using BookShelf.Infrastructure.Books;
using BookShelf.Infrastructure.Lookups;
using BookShelf.Infrastructure.Mapper;
using BookShelf.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Read connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with SQL Server provider
builder.Services.AddDbContext<BookShelfDbContext>(options =>
    options.UseSqlServer(connectionString));

// AutoMapper – scan the Infrastructure assembly for profiles
builder.Services.AddAutoMapper(
    cfg => { },                             // config action (empty is fine)
    AppDomain.CurrentDomain.GetAssemblies() // assemblies to scan for Profiles
);

// Repositories
builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<ILookupRepository, efLookupRepository>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Configuration.AddUserSecrets<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // app.MapOpenApi(); // optional, you can keep or remove this
}

// Testing endpoint to verify database connection
app.MapGet("/api/dbcheck", async (BookShelfDbContext db) =>
{
    var count = await db.Books.CountAsync();
    return Results.Ok(new { BookCount = count });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
