namespace SonglerAPI.Endpoints;

public static class GradeEndpoints
{
	public static WebApplication MapGradeEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/grades");

		return app;
	}
}