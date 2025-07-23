namespace Trabzone.Models.Dtos.Blogs.Responses;

public sealed record BlogResponseDto
{
  public Guid Id { get; init; }
  public string Title { get; init; } = default!;
  public string Description { get; init; } = default!;
  public string Content { get; init; } = default!;
  public string Category { get; init; } = default!;
  public string Author { get; init; } = default!;
}