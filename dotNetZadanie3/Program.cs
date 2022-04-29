using dotNetZadanie3.Data;
using dotNetZadanie3.Interfaces;
using dotNetZadanie3.Repositories;
using dotNetZadanie3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<YearsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dotNetZadanie3DB")));
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddTransient<IYearsService, YearsService>();
builder.Services.AddTransient<IYearsRepository, YearsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();

