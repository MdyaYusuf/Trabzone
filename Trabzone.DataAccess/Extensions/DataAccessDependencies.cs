using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trabzone.DataAccess.Abstracts;
using Trabzone.DataAccess.Concretes;
using Trabzone.DataAccess.Contexts;

namespace Trabzone.DataAccess.Extensions;

public static class DataAccessDependencies
{
  public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<ICategoryRepository, EfCategoryRepository>();

    services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

    return services;
  }
}