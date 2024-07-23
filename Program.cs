using InsuranceConsultingOffice.Application.Extensions;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Application.Services;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddInjectionApplication(Configuration); 

// Add services to the container.

builder.Services.AddDbContext<InsuranceDbContext>(options =>
    options.UseSqlServer((new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings").GetValue<string>("InsuranceDBConnection")));

//builder.Services.AddTransient<IPolicyApplication, PolicyApplication>(); // ¿POR QUÉ NO FUNCIONA?

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
