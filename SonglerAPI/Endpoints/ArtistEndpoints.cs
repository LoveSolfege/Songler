using SonglerAPI.Endpoints.General;
using SonglerAPI.Entities;

namespace SonglerAPI.Endpoints;

public static class ArtistEndpoints
{
	public static void MapArtistEndpoints(this WebApplication app)
	{
		var group = app.MapCrudEndpoints<Artist>(
			route: "api/artists",
			tag: "Artists",
			getDbSet: ctx => ctx.Artists
		);
	}
}