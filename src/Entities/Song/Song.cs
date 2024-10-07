using MongoDB.Entities;

namespace Domain.Entities;

[Collection("song")]
public class Song : BaseEntity
{
    public required string MusicURL { get; set; }
}
