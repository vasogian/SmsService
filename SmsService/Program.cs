using Microsoft.EntityFrameworkCore;
using SmsService.Interfaces;
using SmsService.Services;
using SmsService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MessageContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped< IProvider,GreekProvider>();
builder.Services.AddScoped<IProvider,CypriotProvider>();
builder.Services.AddScoped<IProvider,RestOfTheWorldProvider>();
builder.Services.AddScoped<IContextService, ContextService>();


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
