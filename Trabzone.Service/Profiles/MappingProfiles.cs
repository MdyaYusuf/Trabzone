using AutoMapper;
using Trabzone.Models.Dtos.Categories.Requests;
using Trabzone.Models.Dtos.Categories.Responses;
using Trabzone.Models.Entities;

namespace Trabzone.Service.Profiles;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<CreateCategoryRequest, Category>();
    CreateMap<UpdateCategoryRequest, Category>();
    CreateMap<Category, CategoryResponseDto>();
  }
}