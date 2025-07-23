using Trabzone.Core.Entities;

namespace Trabzone.Models.Entities;

public class Blog : Entity<Guid>
{
  public Blog()
  {

  }

  public Blog(string title, string description, string content, int categoryId, Category category, string userId, User user)
  {
    Title = title;
    Description = description;
    Content = content;
    CategoryId = categoryId;
    Category = category;
    UserId = userId;
    User = user;
  }

  public string Title { get; set; } = default!;
  public string Description { get; set; } = default!;
  public string Content { get; set; } = default!;
  public int CategoryId { get; set; }
  public Category Category { get; set; } = default!;
  public string UserId { get; set; }
  public User User { get; set; } = default!;
  public List<Comment>? Comments { get; set; }
}