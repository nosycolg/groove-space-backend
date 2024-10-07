namespace Features.Song.ReadOne;

public class Endpoint : EndpointWithoutRequest<List<Response>, Mapper>
{
    public override void Configure()
    {
        Get("song");
        Summary(s =>
        {
            s.Summary = "Retrieve a list of artists.";
            s.Description = "Allows retrieving a list of artists from the database.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var songs = await Data.GetSongsAsync();

         await SendOkAsync(Map.FromEntity(songs), ct);
    }
}