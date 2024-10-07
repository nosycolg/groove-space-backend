using FastEndpoints;

namespace Features.Artist.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("artist");
        Summary(s =>
        {
            s.Summary = "Create a new artist.";
            s.Description = "Allows adding a new artist to the database.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var newArtist = Map.ToEntity(req);

        await newArtist.SaveAsync(cancellation: ct);

        await SendOkAsync(Map.FromEntity(newArtist), ct);
    }
}