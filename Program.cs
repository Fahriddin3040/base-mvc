using Microsoft.EntityFrameworkCore;
using TicketOrdering.Contracts;
using TicketOrdering.Data;
using TicketOrdering.Repositories;
using TicketOrdering.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(ApplicationDbContext));
builder.Services.AddScoped(typeof(ClientRepository));
builder.Services.AddScoped(typeof(TicketRepository));
builder.Services.AddScoped(typeof(TicketService));
builder.Services.AddScoped(typeof(ClientService));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
