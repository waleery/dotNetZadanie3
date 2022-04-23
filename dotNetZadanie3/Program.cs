using dotNetZadanie3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection");;

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityContext>();;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<YearsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dotNetZadanie3DB")));
builder.Services.AddMemoryCache();
builder.Services.AddSession();


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
app.UseAuthentication();;

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();

