using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Trabzone.Models.Entities;

namespace Trabzone.DataAccess.Contexts;

public class BaseDbContext : IdentityDbContext<User, IdentityRole, string>
{
  public BaseDbContext(DbContextOptions opt) : base(opt)
  {

  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Comment> Comments { get; set; }
}