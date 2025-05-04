namespace SonglerAPI.Endpoints;

public static class AlbumEndpoints
{
	public static WebApplication MapAlbumEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/artists/{artistsId}/albums");

		return app;
	}
}