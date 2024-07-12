using DbContextInEfMigrations;
using DbContextInEfMigrations.EfExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<MyDbContext>(optionsBuilder => 
        optionsBuilder
            .UseSqlServer("Server=.;Database=TestDb;Trusted_Connection=true;TrustServerCertificate=true;")
            .WithDbContextEnabledMigrations()
        );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
