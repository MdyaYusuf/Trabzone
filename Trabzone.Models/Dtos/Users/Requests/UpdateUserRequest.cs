namespace Trabzone.Models.Dtos.Users.Requests;

public sealed record UpdateUserRequest(string Email, string UserName, string City, string ProfilePictureUrl);