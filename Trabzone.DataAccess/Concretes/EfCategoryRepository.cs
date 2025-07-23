using Microsoft.EntityFrameworkCore;
using Trabzone.Core.Repositories;
using Trabzone.DataAccess.Abstracts;
using Trabzone.DataAccess.Contexts;
using Trabzone.Models.Entities;

namespace Trabzone.DataAccess.Concretes;

public class EfCategoryRepository : EfBaseRepository<BaseDbContext, Category, int>, ICategoryRepository
{
  public EfCategoryRepository(BaseDbContext context) : base(context)
  {

  }

  public async Task<Category?> GetByNameAsync(string name)
  {
    return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
  }
}