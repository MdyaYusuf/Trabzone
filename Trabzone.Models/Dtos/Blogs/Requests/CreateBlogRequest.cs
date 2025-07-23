namespace Trabzone.Models.Dtos.Blogs.Requests;

public sealed record CreateBlogRequest(string Title, string Description, string Content, int CategoryId, string UserId);
