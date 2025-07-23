using Trabzone.Core.Exceptions;
using Trabzone.DataAccess.Abstracts;
using Trabzone.Models.Entities;

namespace Trabzone.Service.Rules;

public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
{
  public async Task IsCategoryExistAsync(int id)
  {
    Category category = await _categoryRepository.GetByIdAsync(id);

    if (category == null)
    {
      throw new NotFoundException($"{id} numaralı kategori bulunamadı.");
    }
  }

  public async Task IsNameUniqueAsync(string name)
  {
    Category category = await _categoryRepository.GetByNameAsync(name);

    if (category != null)
    {
      throw new BusinessException("Sistemimizde bu isim ile bir kategori zaten bulunmaktadır.");
    }
  }
}