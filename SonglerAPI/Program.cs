using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

//Ignore loops in EF entities
builder.Services.AddControllers()
	.AddJsonOptions(options => 
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Sqlite connection string and registering Db Context in DI container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SongContext>(opts => opts.UseSqlite(connectionString!));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
