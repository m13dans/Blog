using BlogDotNet8.Data;
using BlogDotNet8.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddTransient<IRepository, Repository>();

var app = builder.Build();


app.MapDefaultControllerRoute();

app.Run();
