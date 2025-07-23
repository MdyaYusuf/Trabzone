using Microsoft.AspNetCore.Identity;

namespace Trabzone.Models.Entities;

public class User : IdentityUser
{
  public User()
  {

  }

  public string City { get; set; }
  public string ProfilePictureUrl { get; set; }
  public DateTime BirthDate { get; set; }
  public List<Blog>? Blogs { get; set; }
  public List<Comment>? Comments { get; set; }
}