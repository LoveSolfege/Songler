using SonglerAPI.Endpoints.General;
using SonglerAPI.Entities;

namespace SonglerAPI.Endpoints;

public static class SongEndpoints
{
	public static void MapSongEndpoints(this WebApplication app)
	{
		var group = app.MapCrudEndpoints<Song>(
			route: "api/songs",
			tag: "Songs",
			getDbSet: ctx => ctx.Songs
		);

	}
}