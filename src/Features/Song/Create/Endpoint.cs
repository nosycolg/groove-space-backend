namespace Features.Song.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("song");
        Summary(s =>
        {
            s.Summary = "Create a new song.";
            s.Description = "Allows adding a new song to the database.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var newSong = Map.ToEntity(req);

        await newSong.SaveAsync(cancellation: ct);

        await SendOkAsync(Map.FromEntity(newSong), ct);
    }
}