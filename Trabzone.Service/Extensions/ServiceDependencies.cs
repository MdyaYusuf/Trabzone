using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trabzone.Service.Abstracts;
using Trabzone.Service.Concretes;
using Trabzone.Service.Profiles;
using Trabzone.Service.Rules;

namespace Trabzone.Service.Extensions;

public static class ServiceDependencies
{
  public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
  {
    services.AddAutoMapper(typeof(MappingProfiles));
    services.AddScoped<CategoryBusinessRules>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddFluentValidationAutoValidation();
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    return services;
  }
}