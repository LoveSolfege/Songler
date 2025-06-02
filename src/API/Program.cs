using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

//Ignore loops in EF entities
//builder.Services.AddControllers()
//    .AddJsonOptions(options => 
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddMediatR(Application.AssemblyReference.Assembly);

builder.Services.AddAutoMapper(Application.AssemblyReference.Assembly);

builder.Services.AddDbContext<SongDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
app.UseStatusCodePages();

app.MapGet("/", () => "Hello World!");

app.Run();
