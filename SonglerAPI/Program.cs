using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.DTO;
using SonglerAPI.Endpoints;
using SonglerAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

//Ignore loops in EF entities
builder.Services.AddControllers()
	.AddJsonOptions(options => 
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Sqlite connection string and registering Db Context in DI container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SongContext>(opts => opts.UseSqlite(connectionString!));
//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();


//Map endpoints 
app.MapSongEndpoints();
app.MapAlbumEndpoints();
app.MapArtistEndpoints();

app.Run();
