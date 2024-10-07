using MongoDB.Entities;
namespace Domain.Entities;

public abstract class BaseEntity : Entity, ICreatedOn, IModifiedOn
{
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
