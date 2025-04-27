using Microsoft.EntityFrameworkCore;
using SonglerAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Sqlite connection string and registering Db Context in DI container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SongContext>(opts => opts.UseSqlite(connectionString!));

app.MapGet("/", () => "Hello World!");

app.Run();
