using Ecommerce.Context;
using Ecommerce.Services;
using Microsoft.EntityFrameworkCore;

Environment.SetEnvironmentVariable("ConnStr", "Host=localhost;Database=thedatabase;Username=postgres;Password=1234");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContextPool<MasterContext>(options =>
           options.UseNpgsql(Environment.GetEnvironmentVariable("ConnStr")));

builder.Services.AddTransient<IECommerceService, EcommerceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

