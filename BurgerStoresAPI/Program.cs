using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts.Burgers;
using ServiceContracts.Stores;
using Services.Burgers;
using Services.Stores;
using Repositories;
using RepositoryContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<StoreDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
     
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IBurgerRepository, BurgerRepository>();
builder.Services.AddScoped<IStoreGetterService, StoreGetterService>();
builder.Services.AddScoped<IBurgerGetterService, BurgerGetterService>();
builder.Services.AddScoped<IStoreAdderService, StoreAdderService>();
builder.Services.AddScoped<IStoreDeleterService, StoreDeleterService>();
builder.Services.AddScoped<IStoreUpdaterService, StoreUpdaterService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
