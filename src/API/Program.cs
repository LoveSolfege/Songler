using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

// Ignore loops in EF entities
//builder.Services.AddControllers()
//    .AddJsonOptions(options => 
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add mediatr
builder.Services.AddMediatR(Application.AssemblyReference.Assembly);
// Add automapper
builder.Services.AddAutoMapper(Application.AssemblyReference.Assembly);
// Add DbContext
builder.Services.AddDbContext<SongDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add Repositories
builder.Services.AddScoped<IRepository<Artist>, Repository<Artist>>();
builder.Services.AddScoped<IRepository<Album>, Repository<Album>>();
builder.Services.AddScoped<IRepository<Song>, Repository<Song>>();
builder.Services.AddScoped<IRepository<Grade>, Repository<Grade>>();

// APP ZONE =================
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
app.UseStatusCodePages();

app.MapGet("/", () => "Hello World!");

app.Run();
