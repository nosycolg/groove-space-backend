
namespace Features.Artist.Create;

public class Mapper : Mapper<Request, Response, Domain.Entities.Artist>
{
    public override Domain.Entities.Artist ToEntity(Request req)
    {
        return new Domain.Entities.Artist
        {
            Username = req.Username,
        };
    }

    public override Response FromEntity(Domain.Entities.Artist artist)
    {
        return new Response
        {
            Username = artist.Username,
        };
    }
}