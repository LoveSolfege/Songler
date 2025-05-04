using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.DTO;
using SonglerAPI.Endpoints;
using SonglerAPI.Repository;
using SonglerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

//Ignore loops in EF entities
builder.Services.AddControllers()
	.AddJsonOptions(options => 
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Sqlite connection string 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Registering Db Context in DI container
builder.Services.AddDbContext<SongContext>(opts => opts.UseSqlite(connectionString!));
//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Command Service for Endpoints
builder.Services.AddScoped(typeof(IGenericEntityCommandService<,,>), typeof(GenericEntityCommandService<,,>));

//
var app = builder.Build();
//
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler();
}
app.UseStatusCodePages();
//

app.MapArtistEndpoints()
	.MapAlbumEndpoints()
	.MapSongEndpoints()
	.MapGradeEndpoints();


app.Run();
