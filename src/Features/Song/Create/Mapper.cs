
namespace Features.Song.Create;

public class Mapper : Mapper<Request, Response, Domain.Entities.Song>
{
    public override Domain.Entities.Song ToEntity(Request req)
    {
        return new Domain.Entities.Song
        {
            MusicURL = req.MusicURL,
        };
    }

    public override Response FromEntity(Domain.Entities.Song song)
    {
        return new Response
        {
            MusicURL = song.MusicURL,
        };
    }
}