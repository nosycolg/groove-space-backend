using FastEndpoints;

namespace Features.Artist.ReadOne;

public class Endpoint : EndpointWithoutRequest<List<Response>, Mapper>
{
    public override void Configure()
    {
        Get("artist");
        Summary(s =>
        {
            s.Summary = "Retrieve a list of artists.";
            s.Description = "Allows retrieving a list of artists from the database.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var artists = await Data.GetArtistsAsync();

         await SendOkAsync(Map.FromEntity(artists), ct);
    }
}