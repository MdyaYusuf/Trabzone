namespace Trabzone.Models.Dtos.Users.Requests;

public sealed record RegisterRequest(string UserName, string Email, string Password, string City, DateTime BirthDate);