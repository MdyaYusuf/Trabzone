namespace Trabzone.Models.Dtos.Blogs.Requests;

public sealed record UpdateBlogRequest(string Title, string Description, string Content, int CategoryId);
