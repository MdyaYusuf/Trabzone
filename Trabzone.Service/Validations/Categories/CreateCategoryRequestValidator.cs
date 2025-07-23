using FluentValidation;
using Trabzone.Models.Dtos.Categories.Requests;

namespace Trabzone.Service.Validations.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
  public CreateCategoryRequestValidator()
  {
    RuleFor(c => c.Name)
      .NotEmpty().WithMessage("Kategori ismi boş bırakılamaz.")
      .Length(2, 50).WithMessage("Kategori ismi minimum 2, maksimum 50 karakter olabilir.")
      .Matches(@"^[a-zA-Z\s]*$").WithMessage("Kategori ismi özel karakterler ve sayılar içeremez.");
  }
}