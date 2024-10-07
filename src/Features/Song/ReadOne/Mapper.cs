
namespace Features.Song.ReadOne;

public class Mapper : ResponseMapper<Response, Domain.Entities.Song>
    {
        public List<Response> FromEntity(List<Domain.Entities.Song> songs)
        {
            return songs.Select(c => new Response
            {
                MusicURL = c.MusicURL,
            }).ToList();
        }
    }