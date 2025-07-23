using Trabzone.Core.Repositories;
using Trabzone.Models.Entities;

namespace Trabzone.DataAccess.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
  Task<Category?> GetByNameAsync(string name);
}