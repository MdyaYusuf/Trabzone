namespace Trabzone.Core.Entities;

public class Entity<TId>
{
  protected Entity()
  {

  }

  public Entity(TId id) : this()
  {
    Id = id;
  }

  public TId Id { get; set; }
  public DateTime CreatedDate { get; set; }
  public DateTime? UpdatedDate { get; set; }
}