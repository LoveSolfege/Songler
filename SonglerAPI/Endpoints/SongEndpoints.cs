using SonglerAPI.DTO.Create;
using SonglerAPI.DTO.Response;
using SonglerAPI.Endpoints.General;
using SonglerAPI.Entities;

namespace SonglerAPI.Endpoints;

public static class SongEndpoints
{
	public static void MapSongEndpoints(this WebApplication app)
	{
		var group = app.MapCrudEndpoints<Song, SongCreateDto, SongResponseDto>(
			route: "api/songs",
			tag: "Songs",
			getDbSet: ctx => ctx.Songs
		);

	}
}