using System.Linq.Expressions;
using Trabzone.Core.Responses;
using Trabzone.Models.Dtos.Categories.Requests;
using Trabzone.Models.Dtos.Categories.Responses;
using Trabzone.Models.Entities;

namespace Trabzone.Service.Abstracts;

public interface ICategoryService
{
  Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync(
    bool enableTracking = false,
    bool withDeleted = false,
    Expression<Func<Category, bool>>? filter = null,
    Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
    CancellationToken cancellationToken = default
  );

  Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id);

  Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request);

  Task<ReturnModel<CategoryResponseDto>> RemoveAsync(int id);

  Task<ReturnModel<CategoryResponseDto>> UpdateAsync(UpdateCategoryRequest request);
}