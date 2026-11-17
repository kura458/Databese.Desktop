
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SE4.data.Context;
using SE4.data.Entities;
using SE4.API.Interfaces;
using SE4.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add OpenAPI
builder.Services.AddOpenApi();

// Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Password Hasher
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Register User Service
builder.Services.AddScoped<IUserService, UserService>();

// Register Product Service
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
