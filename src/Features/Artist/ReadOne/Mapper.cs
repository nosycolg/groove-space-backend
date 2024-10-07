
namespace Features.Artist.ReadOne;

public class Mapper : ResponseMapper<Response, Domain.Entities.Artist>
    {
        public List<Response> FromEntity(List<Domain.Entities.Artist> artists)
        {
            return artists.Select(c => new Response
            {
                Username = c.Username,
            }).ToList();
        }
    }