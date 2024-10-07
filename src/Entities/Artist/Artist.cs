using MongoDB.Entities;

namespace Domain.Entities;

[Collection("artist")]
public class Artist : BaseEntity
{
    public required string Username { get; set; }
}
