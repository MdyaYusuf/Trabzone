using Trabzone.Core.Entities;

namespace Trabzone.Models.Entities;

public class Category : Entity<int>
{
  public Category()
  {

  }

  public Category(string name)
  {
    Name = name;
  }

  public string Name { get; set; } = default!;
  public List<Blog>? Blogs { get; set; }
}