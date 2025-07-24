﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabzone.Models.Dtos.Categories.Requests;
using Trabzone.Service.Abstracts;

namespace Trabzone.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
  [HttpGet("getall")]
  public async Task<IActionResult> GetAllAsync()
  {
    var result = await _categoryService.GetAllAsync();

    return Ok(result);
  }

  [HttpPost("add")]
  public async Task<IActionResult> AddAsync([FromBody] CreateCategoryRequest request)
  {
    var result = await _categoryService.AddAsync(request);

    return Ok(result);
  }

  [HttpGet("getbyid/{id}")]
  public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
  {
    var result = await _categoryService.GetByIdAsync(id);

    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteAsync([FromQuery] int id)
  {
    var result = await _categoryService.RemoveAsync(id);

    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryRequest request)
  {
    var result = await _categoryService.UpdateAsync(request);

    return Ok(result);
  }
}