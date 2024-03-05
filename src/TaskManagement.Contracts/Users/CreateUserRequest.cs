namespace TaskManagement.Contracts.Users;

public record CreateUserRequest(
    string UserName,
    string FirstName,
    string LastName,
    string Email);