using TaskManagement.Contracts.Tasks;

namespace TaskManagement.Contracts.Users;

public record UserResponse(
    Guid Id,
    string UserName,
    IEnumerable<ToDoTaskResponse> Tasks);