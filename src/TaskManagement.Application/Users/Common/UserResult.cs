using TaskManagement.Application.ToDoTasks.Common;

namespace TaskManagement.Application.Users.Common;

public record UserResult(
    Guid Id,
    string UserName,
    List<ToDoTaskResult> Tasks);