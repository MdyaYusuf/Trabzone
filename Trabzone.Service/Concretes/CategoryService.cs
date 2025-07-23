using AutoMapper;
using System.Linq.Expressions;
using Trabzone.Core.Responses;
using Trabzone.DataAccess.Abstracts;
using Trabzone.Models.Dtos.Categories.Requests;
using Trabzone.Models.Dtos.Categories.Responses;
using Trabzone.Models.Entities;
using Trabzone.Service.Abstracts;
using Trabzone.Service.Rules;

namespace Trabzone.Service.Concretes;

public class CategoryService(ICategoryRepository _categoryRepository, CategoryBusinessRules _businessRules, IMapper _mapper) : ICategoryService
{
  public async Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request)
  {
    await _businessRules.IsNameUniqueAsync(request.Name);

    Category createdCategory = _mapper.Map<Category>(request);
    await _categoryRepository.AddAsync(createdCategory);
    CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

    return new ReturnModel<CategoryResponseDto>()
    {
      Success = true,
      Message = "Kategori başarılı bir şekilde eklendi.",
      Data = response,
      StatusCode = 201
    };
  }

  public async Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync(bool enableTracking = false, bool withDeleted = false, Expression<Func<Category, bool>>? filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, CancellationToken cancellationToken = default)
  {
    List<Category> categories = await _categoryRepository.GetAllAsync(
      enableTracking,
      withDeleted,
      filter,
      orderBy,
      cancellationToken);

    List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);

    return new ReturnModel<List<CategoryResponseDto>>()
    {
      Success = true,
      Message = "Kategori listesi başarılı bir şekilde getirildi.",
      Data = response,
      StatusCode = 200
    };
  }

  public async Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id)
  {
    await _businessRules.IsCategoryExistAsync(id);

    Category? category = await _categoryRepository.GetByIdAsync(id);
    CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

    return new ReturnModel<CategoryResponseDto>()
    {
      Success = true,
      Message = $"{id} numaralı kategori başarılı bir şekilde getirildi.",
      Data = response,
      StatusCode = 200
    };
  }

  public async Task<ReturnModel<CategoryResponseDto>> RemoveAsync(int id)
  {
    await _businessRules.IsCategoryExistAsync(id);

    Category? deletedCategory = await _categoryRepository.GetByIdAsync(id);
    await _categoryRepository.DeleteAsync(deletedCategory);
    CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);

    return new ReturnModel<CategoryResponseDto>()
    {
      Success = true,
      Message = "Kategori başarılı bir şekilde silindi.",
      Data = response,
      StatusCode = 200
    };
  }

  public async Task<ReturnModel<CategoryResponseDto>> UpdateAsync(UpdateCategoryRequest request)
  {
    await _businessRules.IsCategoryExistAsync(request.Id);
    await _businessRules.IsNameUniqueAsync(request.Name);

    Category existingCategory = await _categoryRepository.GetByIdAsync(request.Id);

    existingCategory.Id = request.Id;
    existingCategory.Name = request.Name;

    Category updatedCategory = await _categoryRepository.UpdateAsync(existingCategory);
    CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(updatedCategory);

    return new ReturnModel<CategoryResponseDto>()
    {
      Success = true,
      Message = "Kategori başarılı bir şekilde güncellendi.",
      Data = response,
      StatusCode = 200
    };
  }
}