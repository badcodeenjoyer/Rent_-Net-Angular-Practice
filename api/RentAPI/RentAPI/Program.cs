using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentAPI.Data;
using RentAPI.Interfaces;
using RentAPI.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentAPIContext")));

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFindRent, FindRentService>();
builder.Services.AddTransient<IDelete, DeleteService>();
builder.Services.AddTransient<ISave, SaveService>();
builder.Services.AddTransient<IAdd, AddService>();
builder.Services.AddTransient<IList, ListService>();
builder.Services.AddTransient<IExist, ExistService>();
builder.Services.AddTransient<IEntry, EntryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => { builder.AllowAnyOrigin();builder.AllowAnyHeader();builder.AllowAnyMethod(); }); 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
