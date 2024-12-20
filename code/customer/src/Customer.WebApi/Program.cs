using Ecommerce.Customer;
using Ecommerce.Customer.WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("Customers"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    CustomerSeed.Seed(dbContext);
}

app.MapCustomerEndpoints();

await app.RunAsync();