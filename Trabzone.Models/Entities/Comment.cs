using Trabzone.Core.Entities;

namespace Trabzone.Models.Entities;

public class Comment : Entity<Guid>
{
  public Comment()
  {

  }

  public Comment(string text, Guid blogId, Blog blog, string userId, User user)
  {
    Text = text;
    BlogId = blogId;
    Blog = blog;
    UserId = userId;
    User = user;
  }

  public string Text { get; set; } = default!;
  public Guid BlogId { get; set; }
  public Blog Blog { get; set; }
  public string UserId { get; set; }
  public User User { get; set; } = default!;
}