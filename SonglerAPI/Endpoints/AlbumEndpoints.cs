using SonglerAPI.DTO.Create;
using SonglerAPI.DTO.Response;
using SonglerAPI.Endpoints.General;
using SonglerAPI.Entities;

namespace SonglerAPI.Endpoints;

public static class AlbumEndpoints
{
	public static void MapAlbumEndpoints(this WebApplication app)
	{
		var group = app.MapCrudEndpoints<Album, AlbumCreateDto, AlbumResponseDto>(
			route: "api/albums",
			tag: "Albums",
			getDbSet: ctx => ctx.Albums
		);
	}
}