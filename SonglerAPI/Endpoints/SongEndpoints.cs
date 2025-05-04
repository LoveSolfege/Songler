namespace SonglerAPI.Endpoints;

public static class SongEndpoints
{
	public static WebApplication MapSongEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/artists/{artistsId}/albums/{albumId}/songs");

		return app;
	}
}